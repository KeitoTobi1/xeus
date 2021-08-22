using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Omnius.Core;
using Omnius.Core.Helpers;
using Omnius.Core.Net;
using Omnius.Core.Net.Caps;
using Omnius.Core.Net.Connections;
using Omnius.Core.Net.Connections.Secure;
using Omnius.Core.Net.Connections.Secure.V1;
using Omnius.Core.Tasks;
using Omnius.Xeus.Engines.Internal.Models;
using Omnius.Xeus.Models;

namespace Omnius.Xeus.Engines
{
    public sealed class SessionConnector : AsyncDisposableBase, ISessionConnector
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly IEnumerable<IConnectionConnector> _connectionConnectors;
        private readonly IBatchActionDispatcher _batchActionDispatcher;
        private readonly IBytesPool _bytesPool;
        private readonly SessionConnectorOptions _options;

        private readonly CancellationTokenSource _cancellationTokenSource = new();

        private const int MaxReceiveByteCount = 1024 * 1024 * 8;

        public SessionConnector(IEnumerable<IConnectionConnector> connectionConnectors, IBatchActionDispatcher batchActionDispatcher, IBytesPool bytesPool, SessionConnectorOptions options)
        {
            _connectionConnectors = connectionConnectors;
            _batchActionDispatcher = batchActionDispatcher;
            _bytesPool = bytesPool;
            _options = options;
        }

        protected override async ValueTask OnDisposeAsync()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }

        public async ValueTask<ISession?> ConnectAsync(OmniAddress address, string scheme, CancellationToken cancellationToken = default)
        {
            foreach (var connectionConnector in _connectionConnectors)
            {
                var connection = await connectionConnector.ConnectAsync(address, cancellationToken);
                if (connection is null) continue;

                var session = await this.CreateSessionAsync(connection, address, scheme, cancellationToken);
                return session;
            }

            return null;
        }

        private async ValueTask<ISession?> CreateSessionAsync(IConnection connection, OmniAddress address, string scheme, CancellationToken cancellationToken)
        {
            using var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            linkedTokenSource.CancelAfter(TimeSpan.FromSeconds(20));

            var sendHelloMessage = new SessionManagerHelloMessage(new[] { SessionManagerVersion.Version1 });
            var receiveHelloMessage = await connection.ExchangeAsync(sendHelloMessage, cancellationToken);

            var version = EnumHelper.GetOverlappedMaxValue(sendHelloMessage.Versions, receiveHelloMessage.Versions);

            if (version == SessionManagerVersion.Version1)
            {
                var secureConnectionOptions = new OmniSecureConnectionOptions(OmniSecureConnectionType.Connected, _options.DigitalSignature, MaxReceiveByteCount);
                var secureConnection = OmniSecureConnection.CreateV1(connection, _batchActionDispatcher, _bytesPool, secureConnectionOptions);

                await secureConnection.HandshakeAsync(linkedTokenSource.Token);
                if (secureConnection.Signature is null) return null;

                var sessionRequestMessage = new SessionManagerSessionRequestMessage(scheme);
                var sessionResultMessage = secureConnection.SendAndReceiveAsync<SessionManagerSessionRequestMessage, SessionManagerSessionResultMessage>(sessionRequestMessage, linkedTokenSource.Token);

                var session = new Session(secureConnection, address, SessionHandshakeType.Connected, secureConnection.Signature, scheme);
                return session;
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}
