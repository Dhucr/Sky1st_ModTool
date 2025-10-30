using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class EyeModifyAttachData : TblNodeData
    {
        [FieldOrder(0)]
        public ushort Id;

        [FieldOrder(1)]
        public ushort Ushort1;

        [FieldOrder(2)]
        public int Int1;

        [FieldOrder(3)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count1")]
        public ushort[]? Arr1;

        [FieldOrder(4)]
        public long Count1;

        [FieldOrder(5)]
        [FieldOffset(FieldType.String)]
        public string? Text;

        [JsonIgnore]
        public override string? DisplayName => Id.ToString();
    }
}