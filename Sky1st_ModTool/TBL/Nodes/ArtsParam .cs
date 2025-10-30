using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class ArtsParam : TblNodeData
    {
        [FieldOrder(0)]
        public int Id;

        [FieldOrder(1)]
        public byte Byte1;

        [FieldOrder(2)]
        public byte Byte2;

        [FieldOrder(3)]
        public byte Byte3;

        [FieldOrder(4)]
        public byte Byte4;

        [FieldOrder(5)]
        public byte Byte5;

        [FieldOrder(6)]
        public byte Byte6;

        [FieldOrder(7)]
        public byte Byte7;

        [FieldOrder(8)]
        public byte Byte8;

        [FieldOrder(9)]
        public byte Byte9;

        [FieldOrder(10)]
        public byte Byte10;

        [FieldOrder(11)]
        public byte Byte11;

        [FieldOrder(12)]
        public byte Byte12;

        [JsonIgnore]
        public override string? DisplayName => Id.ToString();
    }
}