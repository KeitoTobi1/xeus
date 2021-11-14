using Omnius.Xeus.Models;

namespace Omnius.Xeus.Intaractors;

public interface IDashboard
{
    ValueTask AddCloudNodeLocationsAsync(IEnumerable<NodeLocation> nodeLocations, CancellationToken cancellationToken = default);

    ValueTask<NodeLocation> GetMyNodeLocationAsync(CancellationToken cancellationToken = default);

    ValueTask<IEnumerable<SessionReport>> GetSessionsReportAsync(CancellationToken cancellationToken = default);
}
