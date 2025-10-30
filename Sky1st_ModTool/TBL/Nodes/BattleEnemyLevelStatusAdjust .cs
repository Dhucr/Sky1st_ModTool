using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class BattleEnemyLevelStatusAdjust : TblNodeData
    {
        [FieldOrder(0)]
        public ushort DifficultyId;

        [FieldOrder(1)]
        public ushort Level;

        [FieldOrder(2)]
        public int HpMulti;

        [FieldOrder(3)]
        public int StrMulti;

        [FieldOrder(4)]
        public int AtsMulti;

        [FieldOrder(5)]
        public int SpdMulti;

        [JsonIgnore]
        public override string? DisplayName => DifficultyId.ToString();
    }
}