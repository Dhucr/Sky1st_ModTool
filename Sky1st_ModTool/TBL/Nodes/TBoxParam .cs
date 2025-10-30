using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class TBoxParam : TblNodeData
    {
        [FieldOrder(0)]
        [FieldOffset(FieldType.String)]
        public string? Scena;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Name;

        [FieldOrder(2)]
        public long Long1;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? Flag;

        [FieldOrder(4)]
        public long Text;

        [FieldOrder(5)]
        public long HackBoxId;

        [FieldOrder(6)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count1")]
        public ushort[]? ItemList;

        [FieldOrder(7)]
        public long Count1;

        [FieldOrder(8)]
        public long HackBoxThing1;

        [FieldOrder(9)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count2")]
        public ushort[]? HackBoxThing2;

        [FieldOrder(10)]
        public long Count2;

        [JsonIgnore]
        public override string? DisplayName => Name;
    }
}