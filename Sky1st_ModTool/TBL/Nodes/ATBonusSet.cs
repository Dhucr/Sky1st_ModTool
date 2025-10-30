using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class ATBonusSet : TblNodeData
    {
        [FieldOrder(0)]
        public uint Id;

        [FieldOrder(1)]
        public byte PlayerOrFoeValue;

        [FieldOrder(2)]
        public byte GeneralAtBonusChance;

        [FieldOrder(3)]
        public byte HpHealSBonusChance;

        [FieldOrder(4)]
        public byte EpHealSBonusChance;

        [FieldOrder(5)]
        public byte CpHealSBonusChance;

        [FieldOrder(6)]
        public byte HpHealLBonusChance;

        [FieldOrder(7)]
        public byte EpHealLBonusChance;

        [FieldOrder(8)]
        public byte CpHealLBonusChance;

        [FieldOrder(9)]
        public byte CriticalBonusChance;

        [FieldOrder(10)]
        public byte UnknownBonusChance1;

        [FieldOrder(11)]
        public byte UnknownBonusChance2;

        [FieldOrder(12)]
        public byte UnknownBonusChance3;

        [FieldOrder(13)]
        public byte MysteryBonusChance;

        [FieldOrder(14)]
        public byte UnusedByte1;

        [FieldOrder(15)]
        public byte UnusedByte2;

        [FieldOrder(16)]
        public byte UnusedByte3;

        [JsonIgnore]
        public override string? DisplayName => Id.ToString();
    }
}