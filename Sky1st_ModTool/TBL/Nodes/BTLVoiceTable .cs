using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;
using Sky1st_ModTool.Utils;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class BTLVoiceTable : TblNodeData
    {
        [FieldOrder(0)]
        public int Int1;

        [FieldOrder(1)]
        public int Int2;

        [FieldOrder(2)]
        public int Int3;

        [FieldOrder(3)]
        public int Id;

        [FieldOrder(4)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count1")]
        public ushort[]? Arr1;

        [FieldOrder(5)]
        public long Count1;

        [FieldOrder(6)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count2")]
        public ushort[]? Arr2;

        [FieldOrder(7)]
        public long Count2;

        [FieldOrder(8)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count3")]
        public uint[]? Arr3;

        [FieldOrder(9)]
        public long Count3;

        [FieldOrder(10)]
        [FieldOffset(FieldType.String)]
        public string? Text;

        [FieldOrder(11)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count4")]
        [JsonConverter(typeof(ByteArrayConverter))]
        public byte[]? Arr4;

        [FieldOrder(12)]
        public long Count4;

        [JsonIgnore]
        public override string? DisplayName => Id.ToString();
    }
}