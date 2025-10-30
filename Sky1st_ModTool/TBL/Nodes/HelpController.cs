using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class HelpController : TblNodeData
    {
        [FieldOrder(0)]
        public ushort Id;

        [FieldOrder(1)]
        public ushort Id2;

        [FieldOrder(2)]
        public uint Uint;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? Text;

        [JsonIgnore]
        public override string? DisplayName => Text;
    }
}