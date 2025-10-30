using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class PlayRecordData : TblNodeData
    {
        [FieldOrder(0)]
        public long AchievementCategory;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Tag;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? Name;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? AchievedGoal;

        [FieldOrder(4)]
        [FieldOffset(FieldType.String)]
        public string? TodoGoal;

        [JsonIgnore]
        public override string? DisplayName => Name;
    }
}