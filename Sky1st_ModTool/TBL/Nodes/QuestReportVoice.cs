using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class QuestReportVoice : TblNodeData
    {
        [FieldOrder(0)]
        public long Id;

        [FieldOrder(1)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count1")]
        public uint[]? Arr1;

        [FieldOrder(2)]
        public long Count1;

        [FieldOrder(3)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count2")]
        public uint[]? Arr2;

        [FieldOrder(4)]
        public long Count2;

        [FieldOrder(5)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count3")]
        public uint[]? Arr3;

        [FieldOrder(6)]
        public long Count3;

        [FieldOrder(7)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count4")]
        public uint[]? Arr4;

        [FieldOrder(8)]
        public long Count4;

        [FieldOrder(9)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count5")]
        public uint[]? Arr5;

        [FieldOrder(10)]
        public long Count5;

        [JsonIgnore]
        public override string? DisplayName => Id.ToString();
    }
}