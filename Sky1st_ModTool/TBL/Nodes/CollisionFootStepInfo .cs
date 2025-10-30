using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class CollisionFootStepInfo : TblNodeData
    {
        [FieldOrder(0)]
        public int Id1;

        [FieldOrder(1)]
        public int Id2;

        [FieldOrder(2)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count1")]
        public uint[]? Arr1;

        [FieldOrder(3)]
        public int Count1;

        [FieldOrder(4)]
        public int Int1;

        [FieldOrder(5)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count2")]
        public uint[]? Arr2;

        [FieldOrder(6)]
        public int Count2;

        [FieldOrder(7)]
        public int Int2;

        [JsonIgnore]
        public override string? DisplayName => Id1.ToString();
    }
}