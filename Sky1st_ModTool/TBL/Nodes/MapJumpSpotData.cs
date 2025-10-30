using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class MapJumpSpotData : TblNodeData
    {
        [FieldOrder(0)]
        public uint Id;

        [FieldOrder(1)]
        public uint RegionId;

        [FieldOrder(2)]
        public uint AreaId;

        [FieldOrder(3)]
        public uint Int1;

        [FieldOrder(4)]
        [FieldOffset(FieldType.String)]
        public string? PlaceName;

        [FieldOrder(5)]
        public ulong Long1;

        [FieldOrder(6)]
        [FieldOffset(FieldType.String)]
        public string? ScenaFile;

        [FieldOrder(7)]
        public float XCoordinate1;

        [FieldOrder(8)]
        public float YCoordinate1;

        [FieldOrder(9)]
        public float ZCoordinate1;

        [FieldOrder(10)]
        public uint Empty;

        [FieldOrder(11)]
        [FieldOffset(FieldType.String)]
        public string? SubScenaFile;

        [FieldOrder(12)]
        public uint Int2;

        [FieldOrder(13)]
        public float XCoordinate2;

        [FieldOrder(14)]
        public float YCoordinate2;

        [FieldOrder(15)]
        public float ZCoordinate2;

        [FieldOrder(16)]
        public float Angle2;

        [FieldOrder(17)]
        public uint Int3;

        [FieldOrder(18)]
        [FieldOffset(FieldType.String)]
        public string? Tag;

        [FieldOrder(19)]
        public ulong Float1;

        [FieldOrder(20)]
        [FieldOffset(FieldType.String)]
        public string? JumpFile;

        [FieldOrder(21)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count1")]
        public ushort[]? Arr1;

        [FieldOrder(22)]
        public long Count1;

        [FieldOrder(23)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count2")]
        public ushort[]? Arr2;

        [FieldOrder(24)]
        public long Count2;

        [FieldOrder(25)]
        [FieldOffset(FieldType.String)]
        public string? JumpFileNote3;

        [JsonIgnore]
        public override string? DisplayName => PlaceName;
    }
}