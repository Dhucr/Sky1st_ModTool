using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class RealTimeHelpTableData : TblNodeData
    {
        [FieldOrder(0)]
        public uint Id;

        [FieldOrder(1)]
        public uint Uint1;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? Text;

        [FieldOrder(3)]
        public float Float;

        [FieldOrder(4)]
        public uint Uint2;

        [JsonIgnore]
        public override string? DisplayName => Text;
    }
}