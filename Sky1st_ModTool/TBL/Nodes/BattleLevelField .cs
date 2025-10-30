using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class BattleLevelField : TblNodeData
    {
        [FieldOrder(0)]
        public uint DifficultyId;

        [FieldOrder(1)]
        public uint PlayerDamageMultiplier;

        [FieldOrder(2)]
        public uint EnemyDamageMultiplier;

        [FieldOrder(3)]
        public float PlayerStunDamageMultiplier;

        [JsonIgnore]
        public override string? DisplayName => DifficultyId.ToString();
    }
}