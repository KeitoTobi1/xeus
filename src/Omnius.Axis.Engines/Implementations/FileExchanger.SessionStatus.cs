using Omnius.Axis.Engines.Internal.Models;
using Omnius.Core;
using Omnius.Core.Collections;
using Omnius.Core.Cryptography;
using Omnius.Core.Tasks;

namespace Omnius.Axis.Engines;

public sealed partial class FileExchanger
{
    private sealed class SessionStatus : AsyncDisposableBase
    {
        public SessionStatus(ISession session, ExchangeType exchangeType, OmniHash rootHash, IBatchActionDispatcher batchActionDispatcher)
        {
            this.Session = session;
            this.ExchangeType = exchangeType;
            this.RootHash = rootHash;
            this.BatchActionDispatcher = batchActionDispatcher;
            this.LastReceivedTime = DateTime.UtcNow;

            this.SentBlockHashes = new(TimeSpan.FromMinutes(3), TimeSpan.FromSeconds(30), batchActionDispatcher);
            this.ReceivedWantBlockHashes = new(TimeSpan.FromMinutes(3), TimeSpan.FromSeconds(30), batchActionDispatcher);
        }

        protected override async ValueTask OnDisposeAsync()
        {
            await this.Session.DisposeAsync();

            this.SentBlockHashes.Dispose();
            this.ReceivedWantBlockHashes.Dispose();
        }

        public ISession Session { get; }
        public ExchangeType ExchangeType { get; }
        public OmniHash RootHash { get; }
        public IBatchActionDispatcher BatchActionDispatcher { get; }
        public DateTime LastReceivedTime { get; set; }

        public FileExchangerDataMessage? SendingDataMessage { get; set; }

        public VolatileHashSet<OmniHash> SentBlockHashes { get; }

        public VolatileHashSet<OmniHash> ReceivedWantBlockHashes { get; }
    }

    private enum ExchangeType
    {
        Unknown,
        Published,
        Subscribed,
    }
}
