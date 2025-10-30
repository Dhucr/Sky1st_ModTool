using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class ChapterParam : TblNodeData
    {
        [FieldOrder(0)]
        public uint Id;

        [FieldOrder(1)]
        public int Int1;

        [FieldOrder(2)]
        public int Int2;

        [FieldOrder(3)]
        public int Int3;

        [FieldOrder(4)]
        [FieldOffset(FieldType.String)]
        public string? Text1;

        [FieldOrder(5)]
        [FieldOffset(FieldType.String)]
        public string? Text2;

        [FieldOrder(6)]
        [FieldOffset(FieldType.String)]
        public string? Text3;

        [FieldOrder(7)]
        [FieldOffset(FieldType.String)]
        public string? Text4;

        [FieldOrder(8)]
        [FieldOffset(FieldType.String)]
        public string? Empty1;

        [FieldOrder(9)]
        public long Long;

        [FieldOrder(10)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count")]
        public uint[]? Arr;

        [FieldOrder(11)]
        public long Count;

        [FieldOrder(12)]
        [FieldOffset(FieldType.String)]
        public string? Empty2;

        [JsonIgnore]
        public override string? DisplayName => Text2;
    }
}