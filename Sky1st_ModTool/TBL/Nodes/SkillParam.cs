using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class SkillParam : TblNodeData
    {
        [FieldOrder(0)]
        public ushort Id;

        [FieldOrder(1)]
        public int CharacterRestriction;

        [FieldOrder(2)]
        public short Short;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? Flag;

        [FieldOrder(4)]
        public byte Category;

        [FieldOrder(5)]
        public byte Element;

        [FieldOrder(6)]
        public int Empty1;

        [FieldOrder(7)]
        public short Empty2;

        [FieldOrder(8)]
        [FieldOffset(FieldType.String)]
        public string? Flag2;

        [FieldOrder(9)]
        public int RangeType;

        [FieldOrder(10)]
        public float RangeMove;

        [FieldOrder(11)]
        public float RangeAttack;

        [FieldOrder(12)]
        public float RangeAngle;

        [FieldOrder(13)]
        [ArrayLength(5)]
        public ItemEffect[]? Effects;

        [FieldOrder(14)]
        public float StunChance;

        [FieldOrder(15)]
        public ushort CastDelay;

        [FieldOrder(16)]
        public ushort RecoveryDelay;

        [FieldOrder(17)]
        public ushort Cost;

        [FieldOrder(18)]
        public short LevelLearn;

        [FieldOrder(19)]
        public ushort SortId;

        [FieldOrder(20)]
        public short Data;

        [FieldOrder(21)]
        [FieldOffset(FieldType.String)]
        public string? Animation;

        [FieldOrder(22)]
        [FieldOffset(FieldType.String)]
        public string? Name;

        [FieldOrder(23)]
        [FieldOffset(FieldType.String)]
        public string? Description1;

        [FieldOrder(24)]
        [FieldOffset(FieldType.String)]
        public string? Description2;

        [JsonIgnore]
        public override string? DisplayName => Name;
    }
}