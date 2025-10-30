using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class SupportAbilityParam : TblNodeData
    {
        [FieldOrder(0)]
        public byte AbilityId;

        [FieldOrder(1)]
        public byte UpgradeId;

        [FieldOrder(2)]
        public byte Byte1;

        [FieldOrder(3)]
        public byte Byte2;

        [FieldOrder(4)]
        public int Param1;

        [FieldOrder(5)]
        public int Param2;

        [FieldOrder(6)]
        public int Empty1;

        [FieldOrder(7)]
        public int ActivationChance;

        [FieldOrder(8)]
        public int ActivationChanceOverdrive;

        [FieldOrder(9)]
        public int Int3;

        [FieldOrder(10)]
        public int Empty2;

        [FieldOrder(11)]
        [FieldOffset(FieldType.String)]
        public string? Flag;

        [FieldOrder(12)]
        [FieldOffset(FieldType.String)]
        public string? Animation;

        [FieldOrder(13)]
        [FieldOffset(FieldType.String)]
        public string? Name;

        [FieldOrder(14)]
        [FieldOffset(FieldType.String)]
        public string? Description;

        [JsonIgnore]
        public override string? DisplayName => Name;
    }
}