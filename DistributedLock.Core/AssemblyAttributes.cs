﻿using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DistributedLock.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100fd3af56ccc8ed94fffe25bfd651e6a5674f8f20a76d37de800dd0f7380e04f0fde2da6fa200380b14fe398605b6f470c87e5e0a0bf39ae871f07536a4994aa7a0057c4d3bcedc8fef3eecb0c88c2024a1b3289305c2393acd9fb9f9a42d0bd7826738ce864d507575ea3a1fe1746ab19823303269f79379d767949807f494be8")]

// Note: we allow for internals sharing in release only. This allows us to have certain
// internal APIs which are public in DEBUG and internal in RELEASE. That way, we can't
// build in DEBUG if we rely on internal APIs that are not meant to be public
#if !DEBUG
[assembly: InternalsVisibleTo("DistributedLock.WaitHandles, PublicKey=0024000004800000940000000602000000240000525341310004000001000100fd3af56ccc8ed94fffe25bfd651e6a5674f8f20a76d37de800dd0f7380e04f0fde2da6fa200380b14fe398605b6f470c87e5e0a0bf39ae871f07536a4994aa7a0057c4d3bcedc8fef3eecb0c88c2024a1b3289305c2393acd9fb9f9a42d0bd7826738ce864d507575ea3a1fe1746ab19823303269f79379d767949807f494be8")]
[assembly: InternalsVisibleTo("DistributedLock.SqlServer, PublicKey=0024000004800000940000000602000000240000525341310004000001000100fd3af56ccc8ed94fffe25bfd651e6a5674f8f20a76d37de800dd0f7380e04f0fde2da6fa200380b14fe398605b6f470c87e5e0a0bf39ae871f07536a4994aa7a0057c4d3bcedc8fef3eecb0c88c2024a1b3289305c2393acd9fb9f9a42d0bd7826738ce864d507575ea3a1fe1746ab19823303269f79379d767949807f494be8")]
[assembly: InternalsVisibleTo("DistributedLock.Postgres, PublicKey=0024000004800000940000000602000000240000525341310004000001000100fd3af56ccc8ed94fffe25bfd651e6a5674f8f20a76d37de800dd0f7380e04f0fde2da6fa200380b14fe398605b6f470c87e5e0a0bf39ae871f07536a4994aa7a0057c4d3bcedc8fef3eecb0c88c2024a1b3289305c2393acd9fb9f9a42d0bd7826738ce864d507575ea3a1fe1746ab19823303269f79379d767949807f494be8")]
[assembly: InternalsVisibleTo("DistributedLock.Azure, PublicKey=0024000004800000940000000602000000240000525341310004000001000100fd3af56ccc8ed94fffe25bfd651e6a5674f8f20a76d37de800dd0f7380e04f0fde2da6fa200380b14fe398605b6f470c87e5e0a0bf39ae871f07536a4994aa7a0057c4d3bcedc8fef3eecb0c88c2024a1b3289305c2393acd9fb9f9a42d0bd7826738ce864d507575ea3a1fe1746ab19823303269f79379d767949807f494be8")]
#endif
