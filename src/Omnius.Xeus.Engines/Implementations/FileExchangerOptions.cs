using System.Collections.Generic;
using Omnius.Core;

namespace Omnius.Xeus.Engines
{
    public record FileExchangerOptions
    {
        public FileExchangerOptions(uint maxSessionCount)
        {
            this.MaxSessionCount = maxSessionCount;
        }

        public uint MaxSessionCount { get; }
    }
}
