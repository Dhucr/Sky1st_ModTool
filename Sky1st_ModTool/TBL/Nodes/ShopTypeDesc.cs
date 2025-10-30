using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class ShopTypeDesc : TblNodeData
    {
        [FieldOrder(0)]
        public ulong Id;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Flag;

        [FieldOrder(2)]
        public byte Byte1;

        [FieldOrder(3)]
        public byte Byte2;

        [FieldOrder(4)]
        public byte Byte3;

        [FieldOrder(5)]
        public byte Byte4;

        [FieldOrder(6)]
        public byte Byte5;

        [FieldOrder(7)]
        public byte Byte6;

        [FieldOrder(8)]
        public byte Byte7;

        [FieldOrder(9)]
        public byte Byte8;

        [JsonIgnore]
        public override string? DisplayName => Id.ToString();
    }
}