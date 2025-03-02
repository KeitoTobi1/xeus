using Omnius.Core.Net;

namespace Omnius.Axis.Engines;

public record TcpConnectionAccepterOptions
{
    public TcpConnectionAccepterOptions(bool useUpnp, OmniAddress listenAddress)
    {
        this.UseUpnp = useUpnp;
        this.ListenAddress = listenAddress;
    }

    public bool UseUpnp { get; }

    public OmniAddress ListenAddress { get; }
}
