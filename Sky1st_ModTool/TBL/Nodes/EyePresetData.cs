using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class EyePresetData : TblNodeData
    {
        [FieldOrder(0)]
        public short Short1;

        [FieldOrder(1)]
        public byte Id;

        [FieldOrder(2)]
        public byte Byte1;

        [FieldOrder(3)]
        public byte Byte2;

        [FieldOrder(4)]
        public byte Byte3;

        [JsonIgnore]
        public override string? DisplayName => Id.ToString();
    }
}