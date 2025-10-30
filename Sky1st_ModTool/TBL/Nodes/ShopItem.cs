using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class ShopItem : TblNodeData
    {
        [FieldOrder(0)]
        public ushort ShopId;

        [FieldOrder(1)]
        public short ItemId;

        [FieldOrder(2)]
        public int Unknown;

        [FieldOrder(3)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("StartScenaFlagsCount")]
        public ushort[]? StartScenaFlags;

        [FieldOrder(4)]
        public long StartScenaFlagsCount;

        [FieldOrder(5)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("EndScenaFlagsCount")]
        public ushort[]? EndScenaFlags;

        [FieldOrder(6)]
        public int EndScenaFlagsCount;

        [FieldOrder(7)]
        public int Int1;

        [JsonIgnore]
        public override string? DisplayName => ShopId.ToString();
    }
}