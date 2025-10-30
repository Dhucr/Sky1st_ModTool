using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class CostumeAttachOffset : TblNodeData
    {
        [FieldOrder(0)]
        public uint Int0;

        [FieldOrder(1)]
        public int Int1;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? Text;

        [FieldOrder(3)]
        public float Float0;

        [FieldOrder(4)]
        public float Float1;

        [FieldOrder(5)]
        public float Float2;

        [FieldOrder(6)]
        public float Float3;

        [FieldOrder(7)]
        public float Float4;

        [FieldOrder(8)]
        public float Float5;

        [FieldOrder(9)]
        public float Float6;

        [FieldOrder(10)]
        public float Float7;

        [FieldOrder(11)]
        public float Float8;

        [FieldOrder(12)]
        public float Float9;

        [JsonIgnore]
        public override string? DisplayName => Text;
    }
}