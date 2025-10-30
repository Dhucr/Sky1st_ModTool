using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class ItemTableData : TblNodeData
    {
        [FieldOrder(0)]
        public uint ID;

        [FieldOrder(1)]
        public uint CharLimit;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string TextOff1;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string TextOff2;

        [FieldOrder(4)]
        public byte ItemKind;

        [FieldOrder(5)]
        public byte SubItemKind;

        [FieldOrder(6)]
        public ushort ItemIcon;

        [FieldOrder(7)]
        public ushort EffectIcon;

        [FieldOrder(8)]
        public ushort Attr;

        [FieldOrder(9)]
        public ushort Unknown;

        [FieldOrder(10)]
        public ushort Unknown1;

        [FieldOrder(11)]
        public float Unknown2;

        [FieldOrder(12)]
        public float Unknown3;

        [FieldOrder(13)]
        [ArrayLength(5)]
        public ItemEffect[] Effects;

        [FieldOrder(14)]
        public float Unknown4;

        [FieldOrder(15)]
        public uint HP;

        [FieldOrder(16)]
        public uint EP;

        [FieldOrder(17)]
        public uint STR;

        [FieldOrder(18)]
        public uint DEF;

        [FieldOrder(19)]
        public uint AST;

        [FieldOrder(20)]
        public uint ADF;

        [FieldOrder(21)]
        public uint AGL;

        [FieldOrder(22)]
        public uint DEX;

        [FieldOrder(23)]
        public uint Accuracy;

        [FieldOrder(24)]
        public uint Dodge;

        [FieldOrder(25)]
        public uint MagicDodge;

        [FieldOrder(26)]
        public uint Critical;

        [FieldOrder(27)]
        public uint SPD;

        [FieldOrder(28)]
        public uint MOV;

        [FieldOrder(29)]
        public uint UpperLimit;

        [FieldOrder(30)]
        public uint Price;

        [FieldOrder(31)]
        [FieldOffset(FieldType.String)]
        public string Animation;

        [FieldOrder(32)]
        [FieldOffset(FieldType.String)]
        public string Name;

        [FieldOrder(33)]
        [FieldOffset(FieldType.String)]
        public string Description;

        [FieldOrder(34)]
        public uint Unknown5;

        [FieldOrder(35)]
        public uint Unknown6;

        [FieldOrder(36)]
        public uint Unknown7;

        [FieldOrder(37)]
        public uint Unknown8;

        [JsonIgnore]
        public override string? DisplayName => Name;
    }
}