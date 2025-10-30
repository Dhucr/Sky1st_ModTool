using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class MonsterSettingParam : TblNodeData
    {
        [FieldOrder(0)]
        [FieldOffset(FieldType.String)]
        public string? String1;

        [FieldOrder(1)]
        public ulong Id;

        [FieldOrder(2)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count1")]
        public uint[]? Array1;

        [FieldOrder(3)]
        public long Count1;

        [FieldOrder(4)]
        [FieldOffset(FieldType.String)]
        public string? Tag;

        [FieldOrder(5)]
        public ulong Long1;

        [FieldOrder(6)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count2")]
        public ushort[]? Array2;

        [FieldOrder(7)]
        public long Count2;

        [FieldOrder(8)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count3")]
        public ushort[]? Array3;

        [FieldOrder(9)]
        public long Count3;

        [FieldOrder(10)]
        [FieldOffset(FieldType.String)]
        public string? Battle;

        [FieldOrder(11)]
        public long Long2;

        [FieldOrder(12)]
        public float Float1;

        [FieldOrder(13)]
        public float Float2;

        [FieldOrder(14)]
        public float Float3;

        [FieldOrder(15)]
        public float Float4;

        [FieldOrder(16)]
        public uint Unknown1;

        [FieldOrder(17)]
        public uint Unknown2;

        [FieldOrder(18)]
        [FieldOffset(FieldType.String)]
        public string? String7;

        [FieldOrder(19)]
        [FieldOffset(FieldType.String)]
        public string? MoveType;

        [FieldOrder(20)]
        [FieldOffset(FieldType.String)]
        public string? String9;

        [FieldOrder(21)]
        public ulong Long3;

        [FieldOrder(22)]
        public ulong Long4;

        [FieldOrder(23)]
        [FieldOffset(FieldType.String)]
        public string? StringA;

        [JsonIgnore]
        public override string? DisplayName => String1;
    }
}