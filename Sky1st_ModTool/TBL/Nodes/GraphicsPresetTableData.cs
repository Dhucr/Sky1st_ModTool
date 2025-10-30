using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class GraphicsPresetTableData : TblNodeData
    {
        [FieldOrder(0)]
        public long Id;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Text1;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? Text2;

        [FieldOrder(3)]
        public byte Byte1;

        [FieldOrder(4)]
        public byte Byte2;

        [FieldOrder(5)]
        public byte Byte3;

        [FieldOrder(6)]
        public byte Byte4;

        [FieldOrder(7)]
        public byte Byte5;

        [FieldOrder(8)]
        public byte Byte6;

        [FieldOrder(9)]
        public byte Byte7;

        [FieldOrder(10)]
        public byte Byte8;

        [FieldOrder(11)]
        public long Long1;

        [JsonIgnore]
        public override string? DisplayName => Text1;
    }
}