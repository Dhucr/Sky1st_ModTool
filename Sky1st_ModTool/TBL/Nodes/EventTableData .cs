using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class EventTableData : TblNodeData
    {
        [FieldOrder(0)]
        public long Id;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Text1;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? Text2;

        [FieldOrder(3)]
        public long Long1;

        [FieldOrder(4)]
        [FieldOffset(FieldType.String)]
        public string? Text3;

        [FieldOrder(5)]
        [FieldOffset(FieldType.String)]
        public string? Text4;

        [FieldOrder(6)]
        public long Long2;

        [FieldOrder(7)]
        [FieldOffset(FieldType.String)]
        public string? Text5;

        [FieldOrder(8)]
        public uint Uint1;

        [FieldOrder(9)]
        public uint Uint2;

        [FieldOrder(10)]
        [FieldOffset(FieldType.String)]
        public string? Text6;

        [FieldOrder(11)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count")]
        public uint[]? Array;

        [FieldOrder(12)]
        public long Count;

        [FieldOrder(13)]
        public long Long3;

        [FieldOrder(14)]
        public long Long4;

        [FieldOrder(15)]
        [FieldOffset(FieldType.String)]
        public string? Text;

        [FieldOrder(16)]
        public long Long5;

        [JsonIgnore]
        public override string? DisplayName => Text1;
    }
}