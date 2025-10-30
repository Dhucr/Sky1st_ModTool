using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class AchievementTableData : TblNodeData
    {
        [FieldOrder(0)]
        public uint AchievementCategoryId;

        [FieldOrder(1)]
        public uint ChallengeId;

        [FieldOrder(2)]
        public uint AchievementObjective;

        [FieldOrder(3)]
        public uint AchievementObjectiveParam;

        [FieldOrder(4)]
        public long Long1;

        [FieldOrder(5)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Arr1Count")]
        public uint[]? Arr1;

        [FieldOrder(6)]
        public int Arr1Count;

        [FieldOrder(7)]
        public short Short1;

        [FieldOrder(8)]
        public short AchievementId;

        [FieldOrder(9)]
        public int RewardItemId;

        [FieldOrder(10)]
        public int RewardCount;

        [FieldOrder(11)]
        public long Long2;

        [FieldOrder(12)]
        public long Empty;

        [FieldOrder(13)]
        [FieldOffset(FieldType.String)]
        public string? Flag;

        [FieldOrder(14)]
        [FieldOffset(FieldType.String)]
        public string? AchievementName;

        [FieldOrder(15)]
        [FieldOffset(FieldType.String)]
        public string? AchievementDescription;

        [FieldOrder(16)]
        [FieldOffset(FieldType.String)]
        public string? Unknown;

        [JsonIgnore]
        public override string? DisplayName => AchievementName;
    }
}