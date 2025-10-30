using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class EyeLidsPatternNameData : TblNodeData
    {
        [FieldOrder(0)]
        public long Id;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Name;

        [JsonIgnore]
        public override string? DisplayName => Name;
    }
}