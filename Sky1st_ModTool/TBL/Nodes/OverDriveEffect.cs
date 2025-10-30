using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class OverDriveEffect : TblNodeData
    {
        [FieldOrder(0)]
        public int Id;

        [FieldOrder(1)]
        public int Int1;

        [FieldOrder(2)]
        public int Int2;

        [FieldOrder(3)]
        public int Int3;

        [FieldOrder(4)]
        public int Int4;

        [FieldOrder(5)]
        public int Int5;

        [FieldOrder(6)]
        public int Int6;

        [FieldOrder(7)]
        public int Int7;

        [FieldOrder(8)]
        public int Int8;

        [FieldOrder(9)]
        public int Int9;

        [FieldOrder(10)]
        public int Int10;

        [FieldOrder(11)]
        public int Int11;

        [FieldOrder(12)]
        [FieldOffset(FieldType.String)]
        public string? Text1;

        [FieldOrder(13)]
        [FieldOffset(FieldType.String)]
        public string? Text2;

        [FieldOrder(14)]
        [FieldOffset(FieldType.String)]
        public string? Text3;

        [FieldOrder(15)]
        [FieldOffset(FieldType.String)]
        public string? Text4;

        [FieldOrder(16)]
        [FieldOffset(FieldType.String)]
        public string? Text5;

        [FieldOrder(17)]
        [FieldOffset(FieldType.String)]
        public string? Text6;

        [FieldOrder(18)]
        [FieldOffset(FieldType.String)]
        public string? Text7;

        [JsonIgnore]
        public override string? DisplayName => Id.ToString();
    }
}