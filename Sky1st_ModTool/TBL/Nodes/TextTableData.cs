using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class TextTableData : TblNodeData
    {
        [FieldOrder(0)]
        [FieldOffset(FieldType.String)]
        public string? Key;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Value;

        [JsonIgnore]
        public override string? DisplayName => Key;
    }
}