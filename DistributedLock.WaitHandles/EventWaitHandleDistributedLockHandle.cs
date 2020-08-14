﻿using Medallion.Threading.Internal;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Medallion.Threading.WaitHandles
{
    /// <summary>
    /// See <see cref="IDistributedLockHandle"/>
    /// </summary>
    public sealed class EventWaitHandleDistributedLockHandle : IDistributedLockHandle
    {
        private EventWaitHandle? _event;

        internal EventWaitHandleDistributedLockHandle(EventWaitHandle @event)
        {
            this._event = @event;
        }

        CancellationToken IDistributedLockHandle.HandleLostToken => 
            Volatile.Read(ref this._event) != null ? CancellationToken.None : throw this.ObjectDisposed();

        /// <summary>
        /// Releases the lock
        /// </summary>
        public void Dispose()
        {
            var @event = Interlocked.Exchange(ref this._event, null);
            if (@event != null)
            {
                @event.Set(); // signal
                @event.Dispose();
            }
        }

        /// <summary>
        /// Releases the lock asynchronously
        /// </summary>
        public ValueTask DisposeAsync()
        {
            this.Dispose();
            return default;
        }
    }
}
