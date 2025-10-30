using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class MarkerTableData : TblNodeData
    {
        [FieldOrder(0)]
        public short MapLpIconId;

        [FieldOrder(1)]
        public short FarIconId;

        [FieldOrder(2)]
        public uint Empty1;

        [FieldOrder(3)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("MapIdsCount")]
        public uint[]? MapIds;

        [FieldOrder(4)]
        public long MapIdsCount;

        [FieldOrder(5)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("ShowFlagsCount")]
        public ushort[]? ShowFlags;

        [FieldOrder(6)]
        public long ShowFlagsCount;

        [FieldOrder(7)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("HideFlagsCount")]
        public ushort[]? HideFlags;

        [FieldOrder(8)]
        public int HideFlagsCount;

        [FieldOrder(9)]
        public short PlacementType;

        [FieldOrder(10)]
        public short ChrId;

        [FieldOrder(11)]
        public long QuestId;

        [FieldOrder(12)]
        [FieldOffset(FieldType.String)]
        public string? SceneOrLpName;

        [FieldOrder(13)]
        public uint Empty4;

        [FieldOrder(14)]
        public float XPos;

        [FieldOrder(15)]
        public float YPos;

        [FieldOrder(16)]
        public float ZPos;

        [FieldOrder(17)]
        public float HighlightRadius;

        [FieldOrder(18)]
        public float TriggerRadius;

        [FieldOrder(19)]
        public float TransitionBuffer;

        [FieldOrder(20)]
        public uint Empty5;

        [FieldOrder(21)]
        [FieldOffset(FieldType.String)]
        public string? End;

        [JsonIgnore]
        public override string? DisplayName => SceneOrLpName;
    }
}