using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class BattleLevelTurn : TblNodeData
    {
        [FieldOrder(0)]
        public uint DifficultyId;

        [FieldOrder(1)]
        public uint PlayerDamageMultiplier;

        [FieldOrder(2)]
        public uint EnemyDamageMultiplier;

        [FieldOrder(3)]
        public uint HpOrUnknownMulti1;

        [FieldOrder(4)]
        public uint HpOrUnknownMulti2;

        [FieldOrder(5)]
        public uint EnemySpdMultiplier;

        [FieldOrder(6)]
        public uint Int1;

        [JsonIgnore]
        public override string? DisplayName => DifficultyId.ToString();
    }
}