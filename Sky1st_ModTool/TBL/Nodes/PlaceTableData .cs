using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class PlaceTableData : TblNodeData
    {
        /*[FieldOrder(0)]
        public ushort Id;

        [FieldOrder(1)]
        public uint Id1;

        [FieldOrder(2)]
        public ushort Id2;*/
        [FieldOrder(0)]
        public long Id;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? File1;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? File2;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? File3;

        [FieldOrder(4)]
        public uint Uint1;

        [FieldOrder(5)]
        public float Float1;

        [FieldOrder(6)]
        public uint Uint2;

        [FieldOrder(7)]
        public uint Uint3;

        [FieldOrder(8)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count1")]
        public ushort[]? EmptyArray1;

        [FieldOrder(9)]
        public long Count1;

        [FieldOrder(10)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count2")]
        public ushort[]? EmptyArray2;

        [FieldOrder(11)]
        public int Count2;

        [FieldOrder(12)]
        public float Float2;

        [FieldOrder(13)]
        public ulong Ulong1;

        [FieldOrder(14)]
        [FieldOffset(FieldType.String)]
        public string? Tags;

        [FieldOrder(15)]
        [FieldOffset(FieldType.String)]
        public string? Name;

        [FieldOrder(16)]
        [FieldOffset(FieldType.String)]
        public string? EmptyText;

        [FieldOrder(17)]
        public float Float3;

        [FieldOrder(18)]
        public float Float4;

        [FieldOrder(19)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count3")]
        public uint[]? Arr3;

        [FieldOrder(20)]
        public long Count3;

        [FieldOrder(21)]
        public float Float5;

        [FieldOrder(22)]
        public float Float6;

        [FieldOrder(23)]
        public uint Uint4;

        [FieldOrder(24)]
        public uint Uint5;

        [FieldOrder(25)]
        public uint Uint6;

        [FieldOrder(26)]
        public float Float7;

        [FieldOrder(27)]
        public float Float8;

        [FieldOrder(28)]
        public float Float9;

        [JsonIgnore]
        public override string? DisplayName => Name;
    }
}