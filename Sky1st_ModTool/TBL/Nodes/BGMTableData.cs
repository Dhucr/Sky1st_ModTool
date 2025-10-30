using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class BGMTableData : TblNodeData
    {
        [FieldOrder(0)]
        public long ID;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Text;

        [FieldOrder(2)]
        public float Float1;

        [FieldOrder(3)]
        public int Int1;

        [JsonIgnore]
        public override string? DisplayName => Text;
    }
}