using Omnius.Core.Cryptography;
using Omnius.Core.Network;
using Omnius.Xeus.Components.Models;

#nullable enable

namespace Omnius.Xeus.Components.Engines.Internal.Models
{
    internal enum NodeFinderVersion : sbyte
    {
        Unknown = 0,
        Version1 = 1,
    }
    internal enum ContentExchangerVersion : byte
    {
        Unknown = 0,
        Version1 = 1,
    }
    internal enum ContentExchangerRequestExchangeResultType : byte
    {
        Unknown = 0,
        Rejected = 1,
        Accepted = 2,
    }
    internal enum DeclaredMessageExchangerVersion : byte
    {
        Unknown = 0,
        Version1 = 1,
    }
    internal enum DeclaredMessageExchangerFetchResultType : byte
    {
        Unknown = 0,
        Rejected = 1,
        Found = 2,
        NotFound = 3,
        Same = 4,
    }
    internal sealed partial class ResourceLocation : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation>.Formatter;
        public static global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation>.Empty;

        static ResourceLocation()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation>.Empty = new global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation(ResourceTag.Empty, global::System.Array.Empty<NodeProfile>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxNodeProfilesCount = 8192;

        public ResourceLocation(ResourceTag resourceTag, NodeProfile[] nodeProfiles)
        {
            if (resourceTag is null) throw new global::System.ArgumentNullException("resourceTag");
            if (nodeProfiles is null) throw new global::System.ArgumentNullException("nodeProfiles");
            if (nodeProfiles.Length > 8192) throw new global::System.ArgumentOutOfRangeException("nodeProfiles");
            foreach (var n in nodeProfiles)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }

            this.ResourceTag = resourceTag;
            this.NodeProfiles = new global::Omnius.Core.Collections.ReadOnlyListSlim<NodeProfile>(nodeProfiles);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (resourceTag != default) ___h.Add(resourceTag.GetHashCode());
                foreach (var n in nodeProfiles)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public ResourceTag ResourceTag { get; }
        public global::Omnius.Core.Collections.ReadOnlyListSlim<NodeProfile> NodeProfiles { get; }

        public static global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation? left, global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation? left, global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation)) return false;
            return this.Equals((global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation)other);
        }
        public bool Equals(global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.ResourceTag != target.ResourceTag) return false;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.NodeProfiles, target.NodeProfiles)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.ResourceTag != ResourceTag.Empty)
                {
                    w.Write((uint)1);
                    global::Omnius.Xeus.Components.Models.ResourceTag.Formatter.Serialize(ref w, value.ResourceTag, rank + 1);
                }
                if (value.NodeProfiles.Count != 0)
                {
                    w.Write((uint)2);
                    w.Write((uint)value.NodeProfiles.Count);
                    foreach (var n in value.NodeProfiles)
                    {
                        global::Omnius.Xeus.Components.Models.NodeProfile.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
                w.Write((uint)0);
            }

            public global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                ResourceTag p_resourceTag = ResourceTag.Empty;
                NodeProfile[] p_nodeProfiles = global::System.Array.Empty<NodeProfile>();

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_resourceTag = global::Omnius.Xeus.Components.Models.ResourceTag.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                        case 2:
                            {
                                var length = r.GetUInt32();
                                p_nodeProfiles = new NodeProfile[length];
                                for (int i = 0; i < p_nodeProfiles.Length; i++)
                                {
                                    p_nodeProfiles[i] = global::Omnius.Xeus.Components.Models.NodeProfile.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                    }
                }

                return new global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation(p_resourceTag, p_nodeProfiles);
            }
        }
    }
    internal sealed partial class ContentBlock : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlock>, global::System.IDisposable
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlock> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlock>.Formatter;
        public static global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlock Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlock>.Empty;

        static ContentBlock()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlock>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlock>.Empty = new global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlock(OmniHash.Empty, global::Omnius.Core.MemoryOwner<byte>.Empty);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxValueLength = 4194304;

        public ContentBlock(OmniHash hash, global::System.Buffers.IMemoryOwner<byte> value)
        {
            if (value is null) throw new global::System.ArgumentNullException("value");
            if (value.Memory.Length > 4194304) throw new global::System.ArgumentOutOfRangeException("value");

            this.Hash = hash;
            _value = value;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (hash != default) ___h.Add(hash.GetHashCode());
                if (!value.Memory.IsEmpty) ___h.Add(global::Omnius.Core.Helpers.ObjectHelper.GetHashCode(value.Memory.Span));
                return ___h.ToHashCode();
            });
        }

        public OmniHash Hash { get; }
        private readonly global::System.Buffers.IMemoryOwner<byte> _value;
        public global::System.ReadOnlyMemory<byte> Value => _value.Memory;

        public static global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlock Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlock? left, global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlock? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlock? left, global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlock? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlock)) return false;
            return this.Equals((global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlock)other);
        }
        public bool Equals(global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlock? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.Hash != target.Hash) return false;
            if (!global::Omnius.Core.BytesOperations.Equals(this.Value.Span, target.Value.Span)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        public void Dispose()
        {
            _value?.Dispose();
        }

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlock>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlock value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.Hash != OmniHash.Empty)
                {
                    w.Write((uint)1);
                    global::Omnius.Core.Cryptography.OmniHash.Formatter.Serialize(ref w, value.Hash, rank + 1);
                }
                if (!value.Value.IsEmpty)
                {
                    w.Write((uint)2);
                    w.Write(value.Value.Span);
                }
                w.Write((uint)0);
            }

            public global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlock Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                OmniHash p_hash = OmniHash.Empty;
                global::System.Buffers.IMemoryOwner<byte> p_value = global::Omnius.Core.MemoryOwner<byte>.Empty;

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_hash = global::Omnius.Core.Cryptography.OmniHash.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                        case 2:
                            {
                                p_value = r.GetRecyclableMemory(4194304);
                                break;
                            }
                    }
                }

                return new global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlock(p_hash, p_value);
            }
        }
    }
    internal sealed partial class ContentBlockFlags : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlockFlags>, global::System.IDisposable
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlockFlags> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlockFlags>.Formatter;
        public static global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlockFlags Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlockFlags>.Empty;

        static ContentBlockFlags()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlockFlags>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlockFlags>.Empty = new global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlockFlags(0, global::Omnius.Core.MemoryOwner<byte>.Empty);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxFlagsLength = 4194304;

        public ContentBlockFlags(int depth, global::System.Buffers.IMemoryOwner<byte> flags)
        {
            if (flags is null) throw new global::System.ArgumentNullException("flags");
            if (flags.Memory.Length > 4194304) throw new global::System.ArgumentOutOfRangeException("flags");

            this.Depth = depth;
            _flags = flags;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (depth != default) ___h.Add(depth.GetHashCode());
                if (!flags.Memory.IsEmpty) ___h.Add(global::Omnius.Core.Helpers.ObjectHelper.GetHashCode(flags.Memory.Span));
                return ___h.ToHashCode();
            });
        }

        public int Depth { get; }
        private readonly global::System.Buffers.IMemoryOwner<byte> _flags;
        public global::System.ReadOnlyMemory<byte> Flags => _flags.Memory;

        public static global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlockFlags Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlockFlags? left, global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlockFlags? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlockFlags? left, global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlockFlags? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlockFlags)) return false;
            return this.Equals((global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlockFlags)other);
        }
        public bool Equals(global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlockFlags? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.Depth != target.Depth) return false;
            if (!global::Omnius.Core.BytesOperations.Equals(this.Flags.Span, target.Flags.Span)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        public void Dispose()
        {
            _flags?.Dispose();
        }

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlockFlags>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlockFlags value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.Depth != 0)
                {
                    w.Write((uint)1);
                    w.Write(value.Depth);
                }
                if (!value.Flags.IsEmpty)
                {
                    w.Write((uint)2);
                    w.Write(value.Flags.Span);
                }
                w.Write((uint)0);
            }

            public global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlockFlags Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                int p_depth = 0;
                global::System.Buffers.IMemoryOwner<byte> p_flags = global::Omnius.Core.MemoryOwner<byte>.Empty;

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_depth = r.GetInt32();
                                break;
                            }
                        case 2:
                            {
                                p_flags = r.GetRecyclableMemory(4194304);
                                break;
                            }
                    }
                }

                return new global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlockFlags(p_depth, p_flags);
            }
        }
    }
    internal sealed partial class NodeFinderHelloMessage : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderHelloMessage>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderHelloMessage> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderHelloMessage>.Formatter;
        public static global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderHelloMessage Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderHelloMessage>.Empty;

        static NodeFinderHelloMessage()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderHelloMessage>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderHelloMessage>.Empty = new global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderHelloMessage(global::System.Array.Empty<NodeFinderVersion>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxVersionsCount = 32;

        public NodeFinderHelloMessage(NodeFinderVersion[] versions)
        {
            if (versions is null) throw new global::System.ArgumentNullException("versions");
            if (versions.Length > 32) throw new global::System.ArgumentOutOfRangeException("versions");

            this.Versions = new global::Omnius.Core.Collections.ReadOnlyListSlim<NodeFinderVersion>(versions);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                foreach (var n in versions)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnius.Core.Collections.ReadOnlyListSlim<NodeFinderVersion> Versions { get; }

        public static global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderHelloMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderHelloMessage? left, global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderHelloMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderHelloMessage? left, global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderHelloMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderHelloMessage)) return false;
            return this.Equals((global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderHelloMessage)other);
        }
        public bool Equals(global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderHelloMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.Versions, target.Versions)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderHelloMessage>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderHelloMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.Versions.Count != 0)
                {
                    w.Write((uint)1);
                    w.Write((uint)value.Versions.Count);
                    foreach (var n in value.Versions)
                    {
                        w.Write((long)n);
                    }
                }
                w.Write((uint)0);
            }

            public global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderHelloMessage Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                NodeFinderVersion[] p_versions = global::System.Array.Empty<NodeFinderVersion>();

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                var length = r.GetUInt32();
                                p_versions = new NodeFinderVersion[length];
                                for (int i = 0; i < p_versions.Length; i++)
                                {
                                    p_versions[i] = (NodeFinderVersion)r.GetInt64();
                                }
                                break;
                            }
                    }
                }

                return new global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderHelloMessage(p_versions);
            }
        }
    }
    internal sealed partial class NodeFinderProfileMessage : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderProfileMessage>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderProfileMessage> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderProfileMessage>.Formatter;
        public static global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderProfileMessage Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderProfileMessage>.Empty;

        static NodeFinderProfileMessage()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderProfileMessage>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderProfileMessage>.Empty = new global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderProfileMessage(global::System.ReadOnlyMemory<byte>.Empty, NodeProfile.Empty);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxIdLength = 32;

        public NodeFinderProfileMessage(global::System.ReadOnlyMemory<byte> id, NodeProfile nodeProfile)
        {
            if (id.Length > 32) throw new global::System.ArgumentOutOfRangeException("id");
            if (nodeProfile is null) throw new global::System.ArgumentNullException("nodeProfile");

            this.Id = id;
            this.NodeProfile = nodeProfile;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (!id.IsEmpty) ___h.Add(global::Omnius.Core.Helpers.ObjectHelper.GetHashCode(id.Span));
                if (nodeProfile != default) ___h.Add(nodeProfile.GetHashCode());
                return ___h.ToHashCode();
            });
        }

        public global::System.ReadOnlyMemory<byte> Id { get; }
        public NodeProfile NodeProfile { get; }

        public static global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderProfileMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderProfileMessage? left, global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderProfileMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderProfileMessage? left, global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderProfileMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderProfileMessage)) return false;
            return this.Equals((global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderProfileMessage)other);
        }
        public bool Equals(global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderProfileMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnius.Core.BytesOperations.Equals(this.Id.Span, target.Id.Span)) return false;
            if (this.NodeProfile != target.NodeProfile) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderProfileMessage>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderProfileMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (!value.Id.IsEmpty)
                {
                    w.Write((uint)1);
                    w.Write(value.Id.Span);
                }
                if (value.NodeProfile != NodeProfile.Empty)
                {
                    w.Write((uint)2);
                    global::Omnius.Xeus.Components.Models.NodeProfile.Formatter.Serialize(ref w, value.NodeProfile, rank + 1);
                }
                w.Write((uint)0);
            }

            public global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderProfileMessage Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                global::System.ReadOnlyMemory<byte> p_id = global::System.ReadOnlyMemory<byte>.Empty;
                NodeProfile p_nodeProfile = NodeProfile.Empty;

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_id = r.GetMemory(32);
                                break;
                            }
                        case 2:
                            {
                                p_nodeProfile = global::Omnius.Xeus.Components.Models.NodeProfile.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                    }
                }

                return new global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderProfileMessage(p_id, p_nodeProfile);
            }
        }
    }
    internal sealed partial class NodeFinderDataMessage : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderDataMessage>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderDataMessage> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderDataMessage>.Formatter;
        public static global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderDataMessage Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderDataMessage>.Empty;

        static NodeFinderDataMessage()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderDataMessage>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderDataMessage>.Empty = new global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderDataMessage(global::System.Array.Empty<NodeProfile>(), global::System.Array.Empty<ResourceLocation>(), global::System.Array.Empty<ResourceTag>(), global::System.Array.Empty<ResourceLocation>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxPushNodeProfilesCount = 256;
        public static readonly int MaxPushResourceLocationsCount = 256;
        public static readonly int MaxWantResourceLocationsCount = 256;
        public static readonly int MaxGiveResourceLocationsCount = 256;

        public NodeFinderDataMessage(NodeProfile[] pushNodeProfiles, ResourceLocation[] pushResourceLocations, ResourceTag[] wantResourceLocations, ResourceLocation[] giveResourceLocations)
        {
            if (pushNodeProfiles is null) throw new global::System.ArgumentNullException("pushNodeProfiles");
            if (pushNodeProfiles.Length > 256) throw new global::System.ArgumentOutOfRangeException("pushNodeProfiles");
            foreach (var n in pushNodeProfiles)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }
            if (pushResourceLocations is null) throw new global::System.ArgumentNullException("pushResourceLocations");
            if (pushResourceLocations.Length > 256) throw new global::System.ArgumentOutOfRangeException("pushResourceLocations");
            foreach (var n in pushResourceLocations)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }
            if (wantResourceLocations is null) throw new global::System.ArgumentNullException("wantResourceLocations");
            if (wantResourceLocations.Length > 256) throw new global::System.ArgumentOutOfRangeException("wantResourceLocations");
            foreach (var n in wantResourceLocations)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }
            if (giveResourceLocations is null) throw new global::System.ArgumentNullException("giveResourceLocations");
            if (giveResourceLocations.Length > 256) throw new global::System.ArgumentOutOfRangeException("giveResourceLocations");
            foreach (var n in giveResourceLocations)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }

            this.PushNodeProfiles = new global::Omnius.Core.Collections.ReadOnlyListSlim<NodeProfile>(pushNodeProfiles);
            this.PushResourceLocations = new global::Omnius.Core.Collections.ReadOnlyListSlim<ResourceLocation>(pushResourceLocations);
            this.WantResourceLocations = new global::Omnius.Core.Collections.ReadOnlyListSlim<ResourceTag>(wantResourceLocations);
            this.GiveResourceLocations = new global::Omnius.Core.Collections.ReadOnlyListSlim<ResourceLocation>(giveResourceLocations);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                foreach (var n in pushNodeProfiles)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                foreach (var n in pushResourceLocations)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                foreach (var n in wantResourceLocations)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                foreach (var n in giveResourceLocations)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnius.Core.Collections.ReadOnlyListSlim<NodeProfile> PushNodeProfiles { get; }
        public global::Omnius.Core.Collections.ReadOnlyListSlim<ResourceLocation> PushResourceLocations { get; }
        public global::Omnius.Core.Collections.ReadOnlyListSlim<ResourceTag> WantResourceLocations { get; }
        public global::Omnius.Core.Collections.ReadOnlyListSlim<ResourceLocation> GiveResourceLocations { get; }

        public static global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderDataMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderDataMessage? left, global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderDataMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderDataMessage? left, global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderDataMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderDataMessage)) return false;
            return this.Equals((global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderDataMessage)other);
        }
        public bool Equals(global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderDataMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.PushNodeProfiles, target.PushNodeProfiles)) return false;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.PushResourceLocations, target.PushResourceLocations)) return false;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.WantResourceLocations, target.WantResourceLocations)) return false;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.GiveResourceLocations, target.GiveResourceLocations)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderDataMessage>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderDataMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.PushNodeProfiles.Count != 0)
                {
                    w.Write((uint)1);
                    w.Write((uint)value.PushNodeProfiles.Count);
                    foreach (var n in value.PushNodeProfiles)
                    {
                        global::Omnius.Xeus.Components.Models.NodeProfile.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
                if (value.PushResourceLocations.Count != 0)
                {
                    w.Write((uint)2);
                    w.Write((uint)value.PushResourceLocations.Count);
                    foreach (var n in value.PushResourceLocations)
                    {
                        global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
                if (value.WantResourceLocations.Count != 0)
                {
                    w.Write((uint)3);
                    w.Write((uint)value.WantResourceLocations.Count);
                    foreach (var n in value.WantResourceLocations)
                    {
                        global::Omnius.Xeus.Components.Models.ResourceTag.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
                if (value.GiveResourceLocations.Count != 0)
                {
                    w.Write((uint)4);
                    w.Write((uint)value.GiveResourceLocations.Count);
                    foreach (var n in value.GiveResourceLocations)
                    {
                        global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
                w.Write((uint)0);
            }

            public global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderDataMessage Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                NodeProfile[] p_pushNodeProfiles = global::System.Array.Empty<NodeProfile>();
                ResourceLocation[] p_pushResourceLocations = global::System.Array.Empty<ResourceLocation>();
                ResourceTag[] p_wantResourceLocations = global::System.Array.Empty<ResourceTag>();
                ResourceLocation[] p_giveResourceLocations = global::System.Array.Empty<ResourceLocation>();

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                var length = r.GetUInt32();
                                p_pushNodeProfiles = new NodeProfile[length];
                                for (int i = 0; i < p_pushNodeProfiles.Length; i++)
                                {
                                    p_pushNodeProfiles[i] = global::Omnius.Xeus.Components.Models.NodeProfile.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                        case 2:
                            {
                                var length = r.GetUInt32();
                                p_pushResourceLocations = new ResourceLocation[length];
                                for (int i = 0; i < p_pushResourceLocations.Length; i++)
                                {
                                    p_pushResourceLocations[i] = global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                        case 3:
                            {
                                var length = r.GetUInt32();
                                p_wantResourceLocations = new ResourceTag[length];
                                for (int i = 0; i < p_wantResourceLocations.Length; i++)
                                {
                                    p_wantResourceLocations[i] = global::Omnius.Xeus.Components.Models.ResourceTag.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                        case 4:
                            {
                                var length = r.GetUInt32();
                                p_giveResourceLocations = new ResourceLocation[length];
                                for (int i = 0; i < p_giveResourceLocations.Length; i++)
                                {
                                    p_giveResourceLocations[i] = global::Omnius.Xeus.Components.Engines.Internal.Models.ResourceLocation.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                    }
                }

                return new global::Omnius.Xeus.Components.Engines.Internal.Models.NodeFinderDataMessage(p_pushNodeProfiles, p_pushResourceLocations, p_wantResourceLocations, p_giveResourceLocations);
            }
        }
    }
    internal sealed partial class ContentExchangerHelloMessage : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerHelloMessage>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerHelloMessage> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerHelloMessage>.Formatter;
        public static global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerHelloMessage Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerHelloMessage>.Empty;

        static ContentExchangerHelloMessage()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerHelloMessage>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerHelloMessage>.Empty = new global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerHelloMessage(global::System.Array.Empty<ContentExchangerVersion>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxVersionsCount = 32;

        public ContentExchangerHelloMessage(ContentExchangerVersion[] versions)
        {
            if (versions is null) throw new global::System.ArgumentNullException("versions");
            if (versions.Length > 32) throw new global::System.ArgumentOutOfRangeException("versions");

            this.Versions = new global::Omnius.Core.Collections.ReadOnlyListSlim<ContentExchangerVersion>(versions);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                foreach (var n in versions)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnius.Core.Collections.ReadOnlyListSlim<ContentExchangerVersion> Versions { get; }

        public static global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerHelloMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerHelloMessage? left, global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerHelloMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerHelloMessage? left, global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerHelloMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerHelloMessage)) return false;
            return this.Equals((global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerHelloMessage)other);
        }
        public bool Equals(global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerHelloMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.Versions, target.Versions)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerHelloMessage>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerHelloMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.Versions.Count != 0)
                {
                    w.Write((uint)1);
                    w.Write((uint)value.Versions.Count);
                    foreach (var n in value.Versions)
                    {
                        w.Write((ulong)n);
                    }
                }
                w.Write((uint)0);
            }

            public global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerHelloMessage Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                ContentExchangerVersion[] p_versions = global::System.Array.Empty<ContentExchangerVersion>();

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                var length = r.GetUInt32();
                                p_versions = new ContentExchangerVersion[length];
                                for (int i = 0; i < p_versions.Length; i++)
                                {
                                    p_versions[i] = (ContentExchangerVersion)r.GetUInt64();
                                }
                                break;
                            }
                    }
                }

                return new global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerHelloMessage(p_versions);
            }
        }
    }
    internal sealed partial class ContentExchangerRequestExchangeMessage : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeMessage>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeMessage> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeMessage>.Formatter;
        public static global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeMessage Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeMessage>.Empty;

        static ContentExchangerRequestExchangeMessage()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeMessage>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeMessage>.Empty = new global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeMessage(OmniHash.Empty);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public ContentExchangerRequestExchangeMessage(OmniHash hash)
        {
            this.Hash = hash;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (hash != default) ___h.Add(hash.GetHashCode());
                return ___h.ToHashCode();
            });
        }

        public OmniHash Hash { get; }

        public static global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeMessage? left, global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeMessage? left, global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeMessage)) return false;
            return this.Equals((global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeMessage)other);
        }
        public bool Equals(global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.Hash != target.Hash) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeMessage>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.Hash != OmniHash.Empty)
                {
                    w.Write((uint)1);
                    global::Omnius.Core.Cryptography.OmniHash.Formatter.Serialize(ref w, value.Hash, rank + 1);
                }
                w.Write((uint)0);
            }

            public global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeMessage Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                OmniHash p_hash = OmniHash.Empty;

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_hash = global::Omnius.Core.Cryptography.OmniHash.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                    }
                }

                return new global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeMessage(p_hash);
            }
        }
    }
    internal sealed partial class ContentExchangerRequestExchangeResultMessage : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeResultMessage>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeResultMessage> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeResultMessage>.Formatter;
        public static global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeResultMessage Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeResultMessage>.Empty;

        static ContentExchangerRequestExchangeResultMessage()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeResultMessage>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeResultMessage>.Empty = new global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeResultMessage((ContentExchangerRequestExchangeResultType)0);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public ContentExchangerRequestExchangeResultMessage(ContentExchangerRequestExchangeResultType type)
        {
            this.Type = type;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (type != default) ___h.Add(type.GetHashCode());
                return ___h.ToHashCode();
            });
        }

        public ContentExchangerRequestExchangeResultType Type { get; }

        public static global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeResultMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeResultMessage? left, global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeResultMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeResultMessage? left, global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeResultMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeResultMessage)) return false;
            return this.Equals((global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeResultMessage)other);
        }
        public bool Equals(global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeResultMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.Type != target.Type) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeResultMessage>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeResultMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.Type != (ContentExchangerRequestExchangeResultType)0)
                {
                    w.Write((uint)1);
                    w.Write((ulong)value.Type);
                }
                w.Write((uint)0);
            }

            public global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeResultMessage Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                ContentExchangerRequestExchangeResultType p_type = (ContentExchangerRequestExchangeResultType)0;

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_type = (ContentExchangerRequestExchangeResultType)r.GetUInt64();
                                break;
                            }
                    }
                }

                return new global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerRequestExchangeResultMessage(p_type);
            }
        }
    }
    internal sealed partial class ContentExchangerDataMessage : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerDataMessage>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerDataMessage> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerDataMessage>.Formatter;
        public static global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerDataMessage Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerDataMessage>.Empty;

        static ContentExchangerDataMessage()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerDataMessage>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerDataMessage>.Empty = new global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerDataMessage(global::System.Array.Empty<NodeProfile>(), global::System.Array.Empty<ContentBlockFlags>(), global::System.Array.Empty<OmniHash>(), global::System.Array.Empty<ContentBlock>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxPushNodeProfilesCount = 256;
        public static readonly int MaxOwnedContentBlockFlagsCount = 32;
        public static readonly int MaxWantContentBlockHashesCount = 256;
        public static readonly int MaxGiveContentBlocksCount = 8;

        public ContentExchangerDataMessage(NodeProfile[] pushNodeProfiles, ContentBlockFlags[] ownedContentBlockFlags, OmniHash[] wantContentBlockHashes, ContentBlock[] giveContentBlocks)
        {
            if (pushNodeProfiles is null) throw new global::System.ArgumentNullException("pushNodeProfiles");
            if (pushNodeProfiles.Length > 256) throw new global::System.ArgumentOutOfRangeException("pushNodeProfiles");
            foreach (var n in pushNodeProfiles)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }
            if (ownedContentBlockFlags is null) throw new global::System.ArgumentNullException("ownedContentBlockFlags");
            if (ownedContentBlockFlags.Length > 32) throw new global::System.ArgumentOutOfRangeException("ownedContentBlockFlags");
            foreach (var n in ownedContentBlockFlags)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }
            if (wantContentBlockHashes is null) throw new global::System.ArgumentNullException("wantContentBlockHashes");
            if (wantContentBlockHashes.Length > 256) throw new global::System.ArgumentOutOfRangeException("wantContentBlockHashes");
            if (giveContentBlocks is null) throw new global::System.ArgumentNullException("giveContentBlocks");
            if (giveContentBlocks.Length > 8) throw new global::System.ArgumentOutOfRangeException("giveContentBlocks");
            foreach (var n in giveContentBlocks)
            {
                if (n is null) throw new global::System.ArgumentNullException("n");
            }

            this.PushNodeProfiles = new global::Omnius.Core.Collections.ReadOnlyListSlim<NodeProfile>(pushNodeProfiles);
            this.OwnedContentBlockFlags = new global::Omnius.Core.Collections.ReadOnlyListSlim<ContentBlockFlags>(ownedContentBlockFlags);
            this.WantContentBlockHashes = new global::Omnius.Core.Collections.ReadOnlyListSlim<OmniHash>(wantContentBlockHashes);
            this.GiveContentBlocks = new global::Omnius.Core.Collections.ReadOnlyListSlim<ContentBlock>(giveContentBlocks);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                foreach (var n in pushNodeProfiles)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                foreach (var n in ownedContentBlockFlags)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                foreach (var n in wantContentBlockHashes)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                foreach (var n in giveContentBlocks)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnius.Core.Collections.ReadOnlyListSlim<NodeProfile> PushNodeProfiles { get; }
        public global::Omnius.Core.Collections.ReadOnlyListSlim<ContentBlockFlags> OwnedContentBlockFlags { get; }
        public global::Omnius.Core.Collections.ReadOnlyListSlim<OmniHash> WantContentBlockHashes { get; }
        public global::Omnius.Core.Collections.ReadOnlyListSlim<ContentBlock> GiveContentBlocks { get; }

        public static global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerDataMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerDataMessage? left, global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerDataMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerDataMessage? left, global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerDataMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerDataMessage)) return false;
            return this.Equals((global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerDataMessage)other);
        }
        public bool Equals(global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerDataMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.PushNodeProfiles, target.PushNodeProfiles)) return false;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.OwnedContentBlockFlags, target.OwnedContentBlockFlags)) return false;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.WantContentBlockHashes, target.WantContentBlockHashes)) return false;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.GiveContentBlocks, target.GiveContentBlocks)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerDataMessage>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerDataMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.PushNodeProfiles.Count != 0)
                {
                    w.Write((uint)1);
                    w.Write((uint)value.PushNodeProfiles.Count);
                    foreach (var n in value.PushNodeProfiles)
                    {
                        global::Omnius.Xeus.Components.Models.NodeProfile.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
                if (value.OwnedContentBlockFlags.Count != 0)
                {
                    w.Write((uint)2);
                    w.Write((uint)value.OwnedContentBlockFlags.Count);
                    foreach (var n in value.OwnedContentBlockFlags)
                    {
                        global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlockFlags.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
                if (value.WantContentBlockHashes.Count != 0)
                {
                    w.Write((uint)3);
                    w.Write((uint)value.WantContentBlockHashes.Count);
                    foreach (var n in value.WantContentBlockHashes)
                    {
                        global::Omnius.Core.Cryptography.OmniHash.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
                if (value.GiveContentBlocks.Count != 0)
                {
                    w.Write((uint)4);
                    w.Write((uint)value.GiveContentBlocks.Count);
                    foreach (var n in value.GiveContentBlocks)
                    {
                        global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlock.Formatter.Serialize(ref w, n, rank + 1);
                    }
                }
                w.Write((uint)0);
            }

            public global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerDataMessage Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                NodeProfile[] p_pushNodeProfiles = global::System.Array.Empty<NodeProfile>();
                ContentBlockFlags[] p_ownedContentBlockFlags = global::System.Array.Empty<ContentBlockFlags>();
                OmniHash[] p_wantContentBlockHashes = global::System.Array.Empty<OmniHash>();
                ContentBlock[] p_giveContentBlocks = global::System.Array.Empty<ContentBlock>();

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                var length = r.GetUInt32();
                                p_pushNodeProfiles = new NodeProfile[length];
                                for (int i = 0; i < p_pushNodeProfiles.Length; i++)
                                {
                                    p_pushNodeProfiles[i] = global::Omnius.Xeus.Components.Models.NodeProfile.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                        case 2:
                            {
                                var length = r.GetUInt32();
                                p_ownedContentBlockFlags = new ContentBlockFlags[length];
                                for (int i = 0; i < p_ownedContentBlockFlags.Length; i++)
                                {
                                    p_ownedContentBlockFlags[i] = global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlockFlags.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                        case 3:
                            {
                                var length = r.GetUInt32();
                                p_wantContentBlockHashes = new OmniHash[length];
                                for (int i = 0; i < p_wantContentBlockHashes.Length; i++)
                                {
                                    p_wantContentBlockHashes[i] = global::Omnius.Core.Cryptography.OmniHash.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                        case 4:
                            {
                                var length = r.GetUInt32();
                                p_giveContentBlocks = new ContentBlock[length];
                                for (int i = 0; i < p_giveContentBlocks.Length; i++)
                                {
                                    p_giveContentBlocks[i] = global::Omnius.Xeus.Components.Engines.Internal.Models.ContentBlock.Formatter.Deserialize(ref r, rank + 1);
                                }
                                break;
                            }
                    }
                }

                return new global::Omnius.Xeus.Components.Engines.Internal.Models.ContentExchangerDataMessage(p_pushNodeProfiles, p_ownedContentBlockFlags, p_wantContentBlockHashes, p_giveContentBlocks);
            }
        }
    }
    internal sealed partial class DeclaredMessageExchangerHelloMessage : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerHelloMessage>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerHelloMessage> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerHelloMessage>.Formatter;
        public static global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerHelloMessage Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerHelloMessage>.Empty;

        static DeclaredMessageExchangerHelloMessage()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerHelloMessage>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerHelloMessage>.Empty = new global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerHelloMessage(global::System.Array.Empty<DeclaredMessageExchangerVersion>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxVersionsCount = 32;

        public DeclaredMessageExchangerHelloMessage(DeclaredMessageExchangerVersion[] versions)
        {
            if (versions is null) throw new global::System.ArgumentNullException("versions");
            if (versions.Length > 32) throw new global::System.ArgumentOutOfRangeException("versions");

            this.Versions = new global::Omnius.Core.Collections.ReadOnlyListSlim<DeclaredMessageExchangerVersion>(versions);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                foreach (var n in versions)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnius.Core.Collections.ReadOnlyListSlim<DeclaredMessageExchangerVersion> Versions { get; }

        public static global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerHelloMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerHelloMessage? left, global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerHelloMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerHelloMessage? left, global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerHelloMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerHelloMessage)) return false;
            return this.Equals((global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerHelloMessage)other);
        }
        public bool Equals(global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerHelloMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.Versions, target.Versions)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerHelloMessage>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerHelloMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.Versions.Count != 0)
                {
                    w.Write((uint)1);
                    w.Write((uint)value.Versions.Count);
                    foreach (var n in value.Versions)
                    {
                        w.Write((ulong)n);
                    }
                }
                w.Write((uint)0);
            }

            public global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerHelloMessage Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                DeclaredMessageExchangerVersion[] p_versions = global::System.Array.Empty<DeclaredMessageExchangerVersion>();

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                var length = r.GetUInt32();
                                p_versions = new DeclaredMessageExchangerVersion[length];
                                for (int i = 0; i < p_versions.Length; i++)
                                {
                                    p_versions[i] = (DeclaredMessageExchangerVersion)r.GetUInt64();
                                }
                                break;
                            }
                    }
                }

                return new global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerHelloMessage(p_versions);
            }
        }
    }
    internal sealed partial class DeclaredMessageExchangerFetchMessage : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchMessage>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchMessage> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchMessage>.Formatter;
        public static global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchMessage Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchMessage>.Empty;

        static DeclaredMessageExchangerFetchMessage()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchMessage>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchMessage>.Empty = new global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchMessage(OmniSignature.Empty, global::Omnius.Core.RocketPack.Timestamp.Zero);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public DeclaredMessageExchangerFetchMessage(OmniSignature signature, global::Omnius.Core.RocketPack.Timestamp creationTime)
        {
            if (signature is null) throw new global::System.ArgumentNullException("signature");
            this.Signature = signature;
            this.CreationTime = creationTime;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (signature != default) ___h.Add(signature.GetHashCode());
                if (creationTime != default) ___h.Add(creationTime.GetHashCode());
                return ___h.ToHashCode();
            });
        }

        public OmniSignature Signature { get; }
        public global::Omnius.Core.RocketPack.Timestamp CreationTime { get; }

        public static global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchMessage? left, global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchMessage? left, global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchMessage)) return false;
            return this.Equals((global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchMessage)other);
        }
        public bool Equals(global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.Signature != target.Signature) return false;
            if (this.CreationTime != target.CreationTime) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchMessage>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.Signature != OmniSignature.Empty)
                {
                    w.Write((uint)1);
                    global::Omnius.Core.Cryptography.OmniSignature.Formatter.Serialize(ref w, value.Signature, rank + 1);
                }
                if (value.CreationTime != global::Omnius.Core.RocketPack.Timestamp.Zero)
                {
                    w.Write((uint)2);
                    w.Write(value.CreationTime);
                }
                w.Write((uint)0);
            }

            public global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchMessage Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                OmniSignature p_signature = OmniSignature.Empty;
                global::Omnius.Core.RocketPack.Timestamp p_creationTime = global::Omnius.Core.RocketPack.Timestamp.Zero;

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_signature = global::Omnius.Core.Cryptography.OmniSignature.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                        case 2:
                            {
                                p_creationTime = r.GetTimestamp();
                                break;
                            }
                    }
                }

                return new global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchMessage(p_signature, p_creationTime);
            }
        }
    }
    internal sealed partial class DeclaredMessageExchangerFetchResultMessage : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchResultMessage>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchResultMessage> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchResultMessage>.Formatter;
        public static global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchResultMessage Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchResultMessage>.Empty;

        static DeclaredMessageExchangerFetchResultMessage()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchResultMessage>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchResultMessage>.Empty = new global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchResultMessage((DeclaredMessageExchangerFetchResultType)0, null);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public DeclaredMessageExchangerFetchResultMessage(DeclaredMessageExchangerFetchResultType type, DeclaredMessage? declaredMessage)
        {
            this.Type = type;
            this.DeclaredMessage = declaredMessage;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (type != default) ___h.Add(type.GetHashCode());
                if (declaredMessage != default) ___h.Add(declaredMessage.GetHashCode());
                return ___h.ToHashCode();
            });
        }

        public DeclaredMessageExchangerFetchResultType Type { get; }
        public DeclaredMessage? DeclaredMessage { get; }

        public static global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchResultMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchResultMessage? left, global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchResultMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchResultMessage? left, global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchResultMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchResultMessage)) return false;
            return this.Equals((global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchResultMessage)other);
        }
        public bool Equals(global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchResultMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.Type != target.Type) return false;
            if ((this.DeclaredMessage is null) != (target.DeclaredMessage is null)) return false;
            if (!(this.DeclaredMessage is null) && !(target.DeclaredMessage is null) && this.DeclaredMessage != target.DeclaredMessage) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchResultMessage>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchResultMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.Type != (DeclaredMessageExchangerFetchResultType)0)
                {
                    w.Write((uint)1);
                    w.Write((ulong)value.Type);
                }
                if (value.DeclaredMessage != null)
                {
                    w.Write((uint)2);
                    global::Omnius.Xeus.Components.Models.DeclaredMessage.Formatter.Serialize(ref w, value.DeclaredMessage, rank + 1);
                }
                w.Write((uint)0);
            }

            public global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchResultMessage Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                DeclaredMessageExchangerFetchResultType p_type = (DeclaredMessageExchangerFetchResultType)0;
                DeclaredMessage? p_declaredMessage = null;

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_type = (DeclaredMessageExchangerFetchResultType)r.GetUInt64();
                                break;
                            }
                        case 2:
                            {
                                p_declaredMessage = global::Omnius.Xeus.Components.Models.DeclaredMessage.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                    }
                }

                return new global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerFetchResultMessage(p_type, p_declaredMessage);
            }
        }
    }
    internal sealed partial class DeclaredMessageExchangerPostMessage : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerPostMessage>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerPostMessage> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerPostMessage>.Formatter;
        public static global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerPostMessage Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerPostMessage>.Empty;

        static DeclaredMessageExchangerPostMessage()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerPostMessage>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerPostMessage>.Empty = new global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerPostMessage(DeclaredMessage.Empty);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public DeclaredMessageExchangerPostMessage(DeclaredMessage declaredMessage)
        {
            if (declaredMessage is null) throw new global::System.ArgumentNullException("declaredMessage");

            this.DeclaredMessage = declaredMessage;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (declaredMessage != default) ___h.Add(declaredMessage.GetHashCode());
                return ___h.ToHashCode();
            });
        }

        public DeclaredMessage DeclaredMessage { get; }

        public static global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerPostMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerPostMessage? left, global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerPostMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerPostMessage? left, global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerPostMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerPostMessage)) return false;
            return this.Equals((global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerPostMessage)other);
        }
        public bool Equals(global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerPostMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.DeclaredMessage != target.DeclaredMessage) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerPostMessage>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerPostMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.DeclaredMessage != DeclaredMessage.Empty)
                {
                    w.Write((uint)1);
                    global::Omnius.Xeus.Components.Models.DeclaredMessage.Formatter.Serialize(ref w, value.DeclaredMessage, rank + 1);
                }
                w.Write((uint)0);
            }

            public global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerPostMessage Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                DeclaredMessage p_declaredMessage = DeclaredMessage.Empty;

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_declaredMessage = global::Omnius.Xeus.Components.Models.DeclaredMessage.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                    }
                }

                return new global::Omnius.Xeus.Components.Engines.Internal.Models.DeclaredMessageExchangerPostMessage(p_declaredMessage);
            }
        }
    }
}
