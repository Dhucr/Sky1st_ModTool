using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class StatusParam : TblNodeData
    {
        [FieldOrder(0)]
        [FieldOffset(FieldType.String)]
        public string? AiFile;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Flag;

        [FieldOrder(2)]
        public ulong Data;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? File1;

        [FieldOrder(4)]
        [FieldOffset(FieldType.String)]
        public string? File2;

        [FieldOrder(5)]
        [FieldOffset(FieldType.String)]
        public string? File3;

        [FieldOrder(6)]
        [FieldOffset(FieldType.String)]
        public string? File4;

        [FieldOrder(7)]
        [FieldOffset(FieldType.String)]
        public string? Unknown;

        [FieldOrder(8)]
        [FieldOffset(FieldType.String)]
        public string? File5;

        [FieldOrder(9)]
        public uint Int1;

        [FieldOrder(10)]
        public float Float1;

        [FieldOrder(11)]
        public float Float2;

        [FieldOrder(12)]
        public float Float3;

        [FieldOrder(13)]
        public float Float4;

        [FieldOrder(14)]
        public float Float5;

        [FieldOrder(15)]
        public float Float6;

        [FieldOrder(16)]
        public float Float7;

        [FieldOrder(17)]
        public float Float8;

        [FieldOrder(18)]
        public float Float9;

        [FieldOrder(19)]
        public float Float10;

        [FieldOrder(20)]
        public float Float11;

        [FieldOrder(21)]
        public float Float12;

        [FieldOrder(22)]
        public float Float13;

        [FieldOrder(23)]
        public float Float14;

        [FieldOrder(24)]
        public float Float15;

        [FieldOrder(25)]
        public float Float16;

        [FieldOrder(26)]
        public float Float17;

        [FieldOrder(27)]
        [FieldOffset(FieldType.String)]
        public string? Flag2;

        [FieldOrder(28)]
        public uint Int2;

        [FieldOrder(29)]
        public uint Int3;

        [FieldOrder(30)]
        public uint Int4;

        [FieldOrder(31)]
        public float Float23;

        [FieldOrder(32)]
        public float Float24;

        [FieldOrder(33)]
        public float Float25;

        [FieldOrder(34)]
        public float Float26;

        [FieldOrder(35)]
        public float Float27;

        [FieldOrder(36)]
        public ushort Short3;

        [FieldOrder(37)]
        public ushort Short4;

        [FieldOrder(38)]
        public ushort Short5;

        [FieldOrder(39)]
        public ushort Short6;

        [FieldOrder(40)]
        public float Float28;

        [FieldOrder(41)]
        public float Float29;

        [FieldOrder(42)]
        public uint Int5;

        [FieldOrder(43)]
        public float Float30;

        [FieldOrder(44)]
        public float Float31;

        [FieldOrder(45)]
        public float Float32;

        [FieldOrder(46)]
        public uint Level;

        [FieldOrder(47)]
        public uint ExpBase;

        [FieldOrder(48)]
        public float ExpGrowth;

        [FieldOrder(49)]
        public uint HpBase;

        [FieldOrder(50)]
        public float HpGrowth;

        [FieldOrder(51)]
        public uint EpBase;

        [FieldOrder(52)]
        public uint CpBase;

        [FieldOrder(53)]
        public float CpGrowth;

        [FieldOrder(54)]
        public uint StrBase;

        [FieldOrder(55)]
        public float StrGrowth;

        [FieldOrder(56)]
        public uint DefBase;

        [FieldOrder(57)]
        public float DefGrowth;

        [FieldOrder(58)]
        public uint AtsBase;

        [FieldOrder(59)]
        public float AtsGrowth;

        [FieldOrder(60)]
        public uint AdfBase;

        [FieldOrder(61)]
        public float AdfGrowth;

        [FieldOrder(62)]
        public uint SpdBase;

        [FieldOrder(63)]
        public float SpdGrowth;

        [FieldOrder(64)]
        public uint AglBase;

        [FieldOrder(65)]
        public float AglGrowth;

        [FieldOrder(66)]
        public uint DexBase;

        [FieldOrder(67)]
        public float DexGrowth;

        [FieldOrder(68)]
        public uint Mov;

        [FieldOrder(69)]
        public uint Rng;

        [FieldOrder(70)]
        public uint Int6;

        [FieldOrder(71)]
        public uint Int7;

        [FieldOrder(72)]
        public uint Int8;

        [FieldOrder(73)]
        public uint Int9;

        [FieldOrder(74)]
        public uint Int10;

        [FieldOrder(75)]
        public uint Int11;

        [FieldOrder(76)]
        public byte PoisonEfficacy;

        [FieldOrder(77)]
        public byte FreezeEfficacy;

        [FieldOrder(78)]
        public byte PetrifyEfficacy;

        [FieldOrder(79)]
        public byte SleepEfficacy;

        [FieldOrder(80)]
        public byte BurnEfficacy;

        [FieldOrder(81)]
        public byte SealEfficacy;

        [FieldOrder(82)]
        public byte MuteEfficacy;

        [FieldOrder(83)]
        public byte BlindEfficacy;

        [FieldOrder(84)]
        public byte ConfuseEfficacy;

        [FieldOrder(85)]
        public byte DeathblowEfficacy;

        [FieldOrder(86)]
        public byte StatdownEfficacy;

        [FieldOrder(87)]
        public byte StunEfficacy;

        [FieldOrder(88)]
        public ushort DelayEfficacy;

        [FieldOrder(89)]
        public ushort EarthEfficacy;

        [FieldOrder(90)]
        public ushort WaterEfficacy;

        [FieldOrder(91)]
        public ushort FireEfficacy;

        [FieldOrder(92)]
        public ushort WindEfficacy;

        [FieldOrder(93)]
        public ushort TimeEfficacy;

        [FieldOrder(94)]
        public ushort SpaceEfficacy;

        [FieldOrder(95)]
        public ushort MirageEfficacy;

        [FieldOrder(96)]
        public byte EarthSepith;

        [FieldOrder(97)]
        public byte WaterSepith;

        [FieldOrder(98)]
        public byte FireSepith;

        [FieldOrder(99)]
        public byte WindSepith;

        [FieldOrder(100)]
        public byte TimeSepith;

        [FieldOrder(101)]
        public byte SpaceSepith;

        [FieldOrder(102)]
        public byte MirageSepith;

        [FieldOrder(103)]
        public byte SepithMass;

        [FieldOrder(104)]
        public long LongForAlly;

        [FieldOrder(105)]
        public uint ItemDrop1;

        [FieldOrder(106)]
        public byte ItemDrop1Min;

        [FieldOrder(107)]
        public byte ItemDrop1Max;

        [FieldOrder(108)]
        public ushort ItemDrop1Rate;

        [FieldOrder(109)]
        public uint ItemDrop2;

        [FieldOrder(110)]
        public byte ItemDrop2Min;

        [FieldOrder(111)]
        public byte ItemDrop2Max;

        [FieldOrder(112)]
        public ushort ItemDrop2Rate;

        [FieldOrder(113)]
        public uint Empty;

        [FieldOrder(114)]
        [FieldOffset(FieldType.String)]
        public string? Name;

        [FieldOrder(115)]
        [FieldOffset(FieldType.String)]
        public string? Description;

        [JsonIgnore]
        public override string? DisplayName => Name;
    }
}