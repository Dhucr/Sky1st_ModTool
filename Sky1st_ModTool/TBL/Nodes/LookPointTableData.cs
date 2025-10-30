using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class LookPointTableData : TblNodeData
    {
        [FieldOrder(0)]
        [FieldOffset(FieldType.String)]
        public string? Text1;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Text2;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? Text3;

        [FieldOrder(3)]
        public long Long1;

        [FieldOrder(4)]
        public long Long2;

        [FieldOrder(5)]
        public long Long3;

        [FieldOrder(6)]
        public long Long4;

        [FieldOrder(7)]
        public long Long5;

        [JsonIgnore]
        public override string? DisplayName => Text2;
    }
}