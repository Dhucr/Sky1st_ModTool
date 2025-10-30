using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class ShopInfo : TblNodeData
    {
        [FieldOrder(0)]
        public ulong Id;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? ShopName;

        [FieldOrder(2)]
        public long Long1;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? Flag;

        [FieldOrder(4)]
        public ushort Empty;

        [FieldOrder(5)]
        public short ShopPricePercent;

        [FieldOrder(6)]
        public float ShopCamPosX;

        [FieldOrder(7)]
        public float ShopCamPosY;

        [FieldOrder(8)]
        public float ShopCamPosZ;

        [FieldOrder(9)]
        public float ShopCamRotation1;

        [FieldOrder(10)]
        public float ShopCamRotation2;

        [FieldOrder(11)]
        public float ShopCamRotation3;

        [FieldOrder(12)]
        public float ShopCamRotation4;

        [FieldOrder(13)]
        public float Float1;

        [FieldOrder(14)]
        public byte Byte1;

        [FieldOrder(15)]
        public byte Byte2;

        [FieldOrder(16)]
        public byte Byte3;

        [FieldOrder(17)]
        public byte Byte4;

        [JsonIgnore]
        public override string? DisplayName => ShopName;
    }
}