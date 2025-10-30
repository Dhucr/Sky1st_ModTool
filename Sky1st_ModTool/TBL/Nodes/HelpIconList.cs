using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class HelpIconList : TblNodeData
    {
        [FieldOrder(0)]
        public ushort Id1;

        [FieldOrder(1)]
        public ushort Id2;

        [FieldOrder(2)]
        public uint Id3;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? Text1;

        [FieldOrder(4)]
        public float Float1;

        [FieldOrder(5)]
        public uint Uint1;

        [FieldOrder(6)]
        [FieldOffset(FieldType.String)]
        public string? Text2;

        [FieldOrder(7)]
        public float Float2;

        [FieldOrder(8)]
        public uint Uint2;

        [FieldOrder(9)]
        [FieldOffset(FieldType.String)]
        public string? Text3;

        [FieldOrder(10)]
        [FieldOffset(FieldType.String)]
        public string? Toffset;

        [JsonIgnore]
        public override string? DisplayName => Text1;
    }
}