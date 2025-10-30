using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class NaviText : TblNodeData
    {
        [FieldOrder(0)]
        public long Long1;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Text1;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? Text2;

        [FieldOrder(3)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count1")]
        public uint[]? Arr1;

        [FieldOrder(4)]
        public long Count1;

        [FieldOrder(5)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count2")]
        public uint[]? Arr2;

        [FieldOrder(6)]
        public long Count2;

        [JsonIgnore]
        public override string? DisplayName => "Item";
    }
}