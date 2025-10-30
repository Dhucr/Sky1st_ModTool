using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class EventBoxTableData : TblNodeData
    {
        [FieldOrder(0)]
        [FieldOffset(FieldType.String)]
        public string? FileName;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? EventName;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? Text;

        [FieldOrder(3)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count1")]
        public ushort[]? Arr1;

        [FieldOrder(4)]
        public long Count1;

        [FieldOrder(5)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count2")]
        public ushort[]? Arr2;

        [FieldOrder(6)]
        public long Count2;

        [JsonIgnore]
        public override string? DisplayName => EventName;
    }
}