using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class FieldItemTableData : TblNodeData
    {
        [FieldOrder(0)]
        [FieldOffset(FieldType.String)]
        public string? Name;

        [FieldOrder(1)]
        public float Float1;

        [FieldOrder(2)]
        public float Float2;

        [FieldOrder(3)]
        public float Float3;

        [FieldOrder(4)]
        public int Int1;

        [FieldOrder(5)]
        public ushort Ushort1;

        [FieldOrder(6)]
        public ushort Ushort2;

        [FieldOrder(7)]
        public int Int2;

        [JsonIgnore]
        public override string? DisplayName => Name;
    }
}