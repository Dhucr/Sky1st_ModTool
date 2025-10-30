using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class HelpOverlayIcon : TblNodeData
    {
        [FieldOrder(0)]
        public ushort Id1;

        [FieldOrder(1)]
        public ushort Id2;

        [FieldOrder(2)]
        public uint Id3;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? Toffset;

        [FieldOrder(4)]
        public float Float1;

        [FieldOrder(5)]
        public float Float2;

        [FieldOrder(6)]
        public uint Uint;

        [FieldOrder(7)]
        public float Float3;

        [FieldOrder(8)]
        public ulong Ulong;

        [JsonIgnore]
        public override string? DisplayName => Toffset;
    }
}