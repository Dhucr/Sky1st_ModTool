using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class MapBGM : TblNodeData
    {
        [FieldOrder(0)]
        public long PlaceId;

        [FieldOrder(1)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count1")]
        public ushort[]? Arr1;

        [FieldOrder(2)]
        public long Count1;

        [FieldOrder(3)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count2")]
        public ushort[]? Arr2;

        [FieldOrder(4)]
        public int Count2;

        [FieldOrder(5)]
        public int Int1;

        [FieldOrder(6)]
        public float Float1;

        [FieldOrder(7)]
        public float Float2;

        [JsonIgnore]
        public override string? DisplayName => PlaceId.ToString();
    }
}