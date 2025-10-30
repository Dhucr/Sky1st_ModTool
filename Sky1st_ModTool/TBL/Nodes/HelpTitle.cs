using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class HelpTitle : TblNodeData
    {
        [FieldOrder(0)]
        public ushort Id1;

        [FieldOrder(1)]
        public ushort Id2;

        [FieldOrder(2)]
        public uint Id3;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? Text;

        [FieldOrder(4)]
        public ulong Ulong1;

        [JsonIgnore]
        public override string? DisplayName => Text;
    }
}