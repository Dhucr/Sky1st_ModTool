using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class MapJumpAreaData : TblNodeData
    {
        [FieldOrder(0)]
        public uint Id;

        [FieldOrder(1)]
        public uint RegionId;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? PlaceName;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? ScenaFile;

        [FieldOrder(4)]
        public float XCoordinate;

        [FieldOrder(5)]
        public float YCoordinate;

        [FieldOrder(6)]
        public float ZCoordinate;

        [FieldOrder(7)]
        public uint Empty;

        [FieldOrder(8)]
        [FieldOffset(FieldType.String)]
        public string? JumpFile;

        [FieldOrder(9)]
        [FieldOffset(FieldType.String)]
        public string? Description;

        [JsonIgnore]
        public override string? DisplayName => PlaceName;
    }
}