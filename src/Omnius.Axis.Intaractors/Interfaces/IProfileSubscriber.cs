using Omnius.Axis.Intaractors.Models;
using Omnius.Core.Cryptography;

namespace Omnius.Axis.Intaractors;

public interface IProfileSubscriber
{
    IAsyncEnumerable<Profile> FindAllAsync(CancellationToken cancellationToken = default);

    ValueTask<Profile?> FindOneAsync(OmniSignature signature, CancellationToken cancellationToken = default);

    ValueTask<ProfileSubscriberConfig> GetConfigAsync(CancellationToken cancellationToken = default);

    ValueTask SetConfigAsync(ProfileSubscriberConfig config, CancellationToken cancellationToken = default);
}
