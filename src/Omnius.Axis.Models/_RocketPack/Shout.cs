using System.Buffers;
using Omnius.Core;
using Omnius.Core.Cryptography;
using Omnius.Core.Pipelines;
using Omnius.Core.RocketPack;

namespace Omnius.Axis.Models;

public sealed partial class Shout
{
    public static Shout Create(Timestamp creationTime, IMemoryOwner<byte> value, OmniDigitalSignature digitalSignature)
    {
        using var bytesPipe = new BytesPipe();
        var target = new Shout(creationTime, value, null);
        target.Export(bytesPipe.Writer, BytesPool.Shared);

        var certificate = OmniDigitalSignature.CreateOmniCertificate(digitalSignature, bytesPipe.Reader.GetSequence());
        return new Shout(creationTime, value, certificate);
    }

    public bool Verify()
    {
        using var bytesPipe = new BytesPipe();
        var target = new Shout(this.CreationTime, this.Value, null);
        target.Export(bytesPipe.Writer, BytesPool.Shared);

        return this.Certificate?.Verify(bytesPipe.Reader.GetSequence()) ?? false;
    }
}
