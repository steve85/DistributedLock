﻿using Medallion.Threading.Internal;
using Medallion.Threading.Internal.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Medallion.Threading.Postgres
{
    /// <summary>
    /// Implements a distributed lock using Postgres advisory locks
    /// (see https://www.postgresql.org/docs/12/functions-admin.html#FUNCTIONS-ADVISORY-LOCKS)
    /// </summary>
    public sealed partial class PostgresDistributedReaderWriterLock : IInternalDistributedReaderWriterLock<PostgresDistributedReaderWriterLockHandle>
    {
        private readonly IDbDistributedLock _internalLock;

        // todo revisit API
        /// <summary>
        /// Constructs a lock with the given <paramref name="key"/> (effectively the lock name), <paramref name="connectionString"/>,
        /// and <paramref name="options"/>
        /// </summary>
        public PostgresDistributedReaderWriterLock(PostgresAdvisoryLockKey key, string connectionString, Action<PostgresConnectionOptionsBuilder>? options = null)
            : this(key, PostgresDistributedLock.CreateInternalLock(key, connectionString, options))
        {
        }

        /// <summary>
        /// Constructs a lock with the given <paramref name="key"/> (effectively the lock name) and <paramref name="connection"/>.
        /// </summary>
        public PostgresDistributedReaderWriterLock(PostgresAdvisoryLockKey key, IDbConnection connection)
            : this(key, PostgresDistributedLock.CreateInternalLock(key, connection))
        {
        }

        private PostgresDistributedReaderWriterLock(PostgresAdvisoryLockKey key, IDbDistributedLock internalLock)
        {
            this.Key = key;
            this._internalLock = internalLock;
        }

        // todo consider API with name
        /// <summary>
        /// Equivalent to <see cref="IDistributedReaderWriterLock.Name"/>
        /// </summary>
        public PostgresAdvisoryLockKey Key { get; }

        string IDistributedReaderWriterLock.Name => this.Key.ToString();

        /// <summary>
        /// Equivalent to TODO
        /// </summary>
        public static PostgresAdvisoryLockKey GetSafeName(string name) => PostgresDistributedLock.GetSafeName(name);

        bool IDistributedReaderWriterLock.IsReentrant => throw new NotImplementedException();

        ValueTask<PostgresDistributedReaderWriterLockHandle?> IInternalDistributedReaderWriterLock<PostgresDistributedReaderWriterLockHandle>.InternalTryAcquireAsync(
            TimeoutValue timeout,
            CancellationToken cancellationToken,
            bool isWrite) =>
            this._internalLock.TryAcquireAsync(timeout, isWrite ? PostgresAdvisoryLock.ExclusiveLock : PostgresAdvisoryLock.SharedLock, cancellationToken, contextHandle: null)
                .Wrap(h => new PostgresDistributedReaderWriterLockHandle(h));
    }
}
