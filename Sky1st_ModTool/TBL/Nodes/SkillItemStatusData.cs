using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class SkillItemStatusData : TblNodeData
    {
        [FieldOrder(0)]
        public long Id;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Name;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? Text1;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? Text2;

        [FieldOrder(4)]
        public long Unknown;

        [FieldOrder(5)]
        [FieldOffset(FieldType.String)]
        public string? Color;

        [JsonIgnore]
        public override string? DisplayName => Name;
    }
}