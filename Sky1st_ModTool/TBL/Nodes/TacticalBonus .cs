using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class TacticalBonus : TblNodeData
    {
        [FieldOrder(0)]
        public uint Id;

        [FieldOrder(1)]
        public byte Byte1;

        [FieldOrder(2)]
        public byte Byte2;

        [FieldOrder(3)]
        public short Empty1;

        [FieldOrder(4)]
        [FieldOffset(FieldType.String)]
        public string? Text;

        [JsonIgnore]
        public override string? DisplayName => Id.ToString();
    }
}