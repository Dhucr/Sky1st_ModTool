using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class SkillRangeHelpData : TblNodeData
    {
        [FieldOrder(0)]
        public long Id;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Name;

        [FieldOrder(2)]
        public long RangeType;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? Text;

        [FieldOrder(4)]
        [FieldOffset(FieldType.String)]
        public string? Color;

        [JsonIgnore]
        public override string? DisplayName => Name;
    }
}