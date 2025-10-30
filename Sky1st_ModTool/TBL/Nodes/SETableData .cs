using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class SETableData : TblNodeData
    {
        [FieldOrder(0)]
        public long Id;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? FileName;

        [FieldOrder(2)]
        public int Int1;

        [FieldOrder(3)]
        public float Float1;

        [FieldOrder(4)]
        public int Int2;

        [FieldOrder(5)]
        public float Float2;

        [JsonIgnore]
        public override string? DisplayName => FileName;
    }
}