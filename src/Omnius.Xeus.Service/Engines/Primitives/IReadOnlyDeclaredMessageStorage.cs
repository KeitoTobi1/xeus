using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Omnius.Core.Cryptography;
using Omnius.Xeus.Service.Engines;
using Omnius.Xeus.Service.Models;

namespace Omnius.Xeus.Service.Engines
{
    public interface IReadOnlyDeclaredMessageStorage
    {
        ValueTask CheckConsistencyAsync(Action<ConsistencyReport> callback, CancellationToken cancellationToken = default);
        ValueTask<IEnumerable<OmniSignature>> GetSignaturesAsync(CancellationToken cancellationToken = default);
        ValueTask<bool> ContainsAsync(OmniSignature signature, DateTime since = default);
        ValueTask<DeclaredMessage?> ReadAsync(OmniSignature signature, CancellationToken cancellationToken = default);
    }
}
