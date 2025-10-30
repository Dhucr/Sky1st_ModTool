using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class AchievementCategoryData : TblNodeData
    {
        [FieldOrder(0)]
        public ulong CategoryId;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? CategoryName;

        [JsonIgnore]
        public override string? DisplayName => CategoryName;
    }
}