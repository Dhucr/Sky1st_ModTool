using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class VoiceTableData : TblNodeData
    {
        [FieldOrder(0)]
        public int Id;

        [FieldOrder(1)]
        public int Int1;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? Filename;

        [FieldOrder(3)]
        public int Int2;

        [FieldOrder(4)]
        public float Float1;

        [FieldOrder(5)]
        public int Int3;

        [FieldOrder(6)]
        public float Float2;

        [FieldOrder(7)]
        [FieldOffset(FieldType.String)]
        public string? Text;

        [JsonIgnore]
        public override string? DisplayName => Filename;
    }
}