using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class SkillPowerIcon : TblNodeData
    {
        [FieldOrder(0)]
        public int SkillPower;

        [FieldOrder(1)]
        public int IconId;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? PowerText;

        [JsonIgnore]
        public override string? DisplayName => PowerText;
    }
}