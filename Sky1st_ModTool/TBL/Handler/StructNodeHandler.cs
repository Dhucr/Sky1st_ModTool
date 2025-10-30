using DynamicData;
using Sky1st_ModTool.TBL.Model;
using Sky1st_ModTool.TBL.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Sky1st_ModTool.TBL.Handler
{
    public class StructNodeHandler : INodeDataHandler
    {
        private static readonly StructNodeHandler _instance = new();
        private readonly Dictionary<string, Type> _nodeTypes;
        private readonly DynamicCompiledManager _compiler;
        public static StructNodeHandler Instance => _instance;

        public StructNodeHandler()
        {
            _nodeTypes = new Dictionary<string, Type>
            {
                ["AchievementCategoryData"] = typeof(AchievementCategoryData),
                ["AchievementTableData"] = typeof(AchievementTableData),
                ["ActiveVoiceTableData"] = typeof(ActiveVoiceTableData),
                ["AniParam"] = typeof(AniParam),
                ["ArtsParam"] = typeof(ArtsParam),
                ["ATBonusParam"] = typeof(ATBonusParam),
                ["ATBonusSet"] = typeof(ATBonusSet),
                ["AttrData"] = typeof(AttrData),
                ["AttrTypeHelpData"] = typeof(AttrTypeHelpData),
                ["BattleBGM"] = typeof(BattleBGM),
                ["BattleEnemyDamageAdjust"] = typeof(BattleEnemyDamageAdjust),
                ["BattleEnemyLevelAdjust"] = typeof(BattleEnemyLevelAdjust),
                ["BattleEnemyLevelStatusAdjust"] = typeof(BattleEnemyLevelStatusAdjust),
                ["BattleLevelField"] = typeof(BattleLevelField),
                ["BattleLevelTurn"] = typeof(BattleLevelTurn),
                ["BattleSCraftDamageRatio"] = typeof(BattleSCraftDamageRatio),
                ["BGMTableData"] = typeof(BGMTableData),
                ["BooksCategory"] = typeof(BooksCategory),
                ["BooksText"] = typeof(BooksText),
                ["BooksTitle"] = typeof(BooksTitle),
                ["BreakObjectTableData"] = typeof(BreakObjectTableData),
                ["BTLVoiceTable"] = typeof(BTLVoiceTable),
                ["ChapterParam"] = typeof(ChapterParam),
                ["CharaArrange"] = typeof(CharaArrange),
                ["CharaSettingInfo"] = typeof(CharaSettingInfo),
                ["ChrDataParam"] = typeof(ChrDataParam),
                ["CollisionFootStepInfo"] = typeof(CollisionFootStepInfo),
                ["ConditionHelpData"] = typeof(ConditionHelpData),
                ["ConditionInfoTableData"] = typeof(ConditionInfoTableData),
                ["ConditionTypeParam"] = typeof(ConditionTypeParam),
                ["ConstantValue"] = typeof(ConstantValue),
                ["CostumeAttachOffset"] = typeof(CostumeAttachOffset),
                ["CostumeParam"] = typeof(CostumeParam),
                ["DLCAppIDConvertTableData"] = typeof(DLCAppIDConvertTableData),
                ["DLCTableData"] = typeof(DLCTableData),
                ["EffectTableData"] = typeof(EffectTableData),
                ["EventBoxTableData"] = typeof(EventBoxTableData),
                ["EventGroupData"] = typeof(EventGroupData),
                ["EventSubGroupData"] = typeof(EventSubGroupData),
                ["EventTableData"] = typeof(EventTableData),
                ["EyeAttachData"] = typeof(EyeAttachData),
                ["EyeBallSizePatternNameData"] = typeof(EyeBallSizePatternNameData),
                ["EyeBrowsPatternNameData"] = typeof(EyeBrowsPatternNameData),
                ["EyeDirPatternNameData"] = typeof(EyeDirPatternNameData),
                ["EyeLidsPatternNameData"] = typeof(EyeLidsPatternNameData),
                ["EyeModifyAttachData"] = typeof(EyeModifyAttachData),
                ["EyeModifyPatternNameData"] = typeof(EyeModifyPatternNameData),
                ["EyePresetData"] = typeof(EyePresetData),
                ["EyeScaleData"] = typeof(EyeScaleData),
                ["FaceAnimeData"] = typeof(FaceAnimeData),
                ["FaceTexturePatternNameData"] = typeof(FaceTexturePatternNameData),
                ["FieldItemTableData"] = typeof(FieldItemTableData),
                ["GraphicsPresetTableData"] = typeof(GraphicsPresetTableData),
                ["HelpController"] = typeof(HelpController),
                ["HelpIconList"] = typeof(HelpIconList),
                ["HelpOverlayIcon"] = typeof(HelpOverlayIcon),
                ["HelpPage"] = typeof(HelpPage),
                ["HelpTitle"] = typeof(HelpTitle),
                //["ItemEffect"] = typeof(ItemEffect),
                ["ItemKindHelpData"] = typeof(ItemKindHelpData),
                ["ItemKindParam2"] = typeof(ItemKindParam2),
                ["ItemShopTabType"] = typeof(ItemShopTabType),
                ["ItemTableData"] = typeof(ItemTableData),
                ["ItemTabType"] = typeof(ItemTabType),
                ["LookPointTableData"] = typeof(LookPointTableData),
                ["MapBGM"] = typeof(MapBGM),
                ["MapJumpAreaData"] = typeof(MapJumpAreaData),
                ["MapJumpSpotData"] = typeof(MapJumpSpotData),
                ["MarkerTableData"] = typeof(MarkerTableData),
                ["MonsterSettingParam"] = typeof(MonsterSettingParam),
                ["MouthPatternMap"] = typeof(MouthPatternMap),
                ["MouthPatternNameData"] = typeof(MouthPatternNameData),
                ["NameTableData"] = typeof(NameTableData),
                ["NaviText"] = typeof(NaviText),
                ["NPCParam"] = typeof(NPCParam),
                ["OrbmentSlotParam"] = typeof(OrbmentSlotParam),
                ["OverDriveEffect"] = typeof(OverDriveEffect),
                ["PlaceTableData"] = typeof(PlaceTableData),
                ["PlayRecordData"] = typeof(PlayRecordData),
                ["PopupFaceParam"] = typeof(PopupFaceParam),
                ["PortraitDataParam"] = typeof(PortraitDataParam),
                ["QuartzParam"] = typeof(QuartzParam),
                ["QuestChapterRank"] = typeof(QuestChapterRank),
                ["QuestRank"] = typeof(QuestRank),
                ["QuestReportVoice"] = typeof(QuestReportVoice),
                ["QuestText"] = typeof(QuestText),
                ["QuestTitle"] = typeof(QuestTitle),
                ["RealTimeHelpTableData"] = typeof(RealTimeHelpTableData),
                ["SceneCommonSetting"] = typeof(SceneCommonSetting),
                ["SceneSkySetting"] = typeof(SceneSkySetting),
                ["SETableData"] = typeof(SETableData),
                ["ShopConv"] = typeof(ShopConv),
                //["ShopEffect"] = typeof(ShopEffect),
                ["ShopInfo"] = typeof(ShopInfo),
                ["ShopItem"] = typeof(ShopItem),
                ["ShopTypeDesc"] = typeof(ShopTypeDesc),
                ["SkillConnectListData"] = typeof(SkillConnectListData),
                ["SkillEffectHelpData"] = typeof(SkillEffectHelpData),
                ["SkillEffectTypeHelpData"] = typeof(SkillEffectTypeHelpData),
                ["SkillGetParam"] = typeof(SkillGetParam),
                ["SkillItemStatusData"] = typeof(SkillItemStatusData),
                ["SkillParam"] = typeof(SkillParam),
                ["SkillPowerIcon"] = typeof(SkillPowerIcon),
                ["SkillRangeData"] = typeof(SkillRangeData),
                ["SkillRangeHelpData"] = typeof(SkillRangeHelpData),
                ["SkillTextArrayData"] = typeof(SkillTextArrayData),
                ["SkillTypeHelpData"] = typeof(SkillTypeHelpData),
                ["StatusParam"] = typeof(StatusParam),
                ["SupportAbilityParam"] = typeof(SupportAbilityParam),
                ["SupportLevelData"] = typeof(SupportLevelData),
                ["TacticalBonus"] = typeof(TacticalBonus),
                ["TalkChrData"] = typeof(TalkChrData),
                ["TBoxParam"] = typeof(TBoxParam),
                ["TextTableData"] = typeof(TextTableData),
                ["TipsTableData"] = typeof(TipsTableData),
                ["TitleTableData"] = typeof(TitleTableData),
                ["TradeItem"] = typeof(TradeItem),
                ["UDSActivityData"] = typeof(UDSActivityData),
                ["VoiceTableData"] = typeof(VoiceTableData),
                ["WeedingTableData"] = typeof(WeedingTableData)
            };
            _compiler = DynamicCompiledManager.Instance;
        }

        public bool CanParse(string nodeName) => _nodeTypes.ContainsKey(nodeName);

        public object? Parse(TblNode node, byte[] fileData)
        {
            if (!_nodeTypes.TryGetValue(node.Name, out var dataType))
                return null;
            var parseMethod = GetType()
                .GetMethod(nameof(ParseWithCompiler), BindingFlags.NonPublic | BindingFlags.Instance)
                ?.MakeGenericMethod(dataType);
            return parseMethod?.Invoke(this, [node, fileData]);
        }

        private List<T> ParseWithCompiler<T>(TblNode node, byte[] fileData) where T : new()
        {
            var deserializer = _compiler.GetDeserializer<T>();
            if (deserializer == null) return new List<T>();
            using var stream = new MemoryStream(fileData);
            using var reader = new BinaryReader(stream);

            stream.Position = node.DataOffset;
            return Enumerable.Range(0, (int)node.DataCount)
                .Select(_ => deserializer(reader, fileData))
                .ToList();
        }

        public void Serialize(BinaryWriter dataWriter, BinaryWriter offsetWriter, object list, string nodeName, int offset)
        {
            if (!_nodeTypes.TryGetValue(nodeName, out var dataType))
                return;
            var serializeMethod = GetType()
                .GetMethod(nameof(SerializeInternal), BindingFlags.NonPublic | BindingFlags.Instance)
                ?.MakeGenericMethod(dataType);
            serializeMethod?.Invoke(this, [dataWriter, offsetWriter, list, offset]);
        }

        private void SerializeInternal<T>(BinaryWriter dataWriter, BinaryWriter offsetWriter, IList list, int offset) where T : new()
        {
            var serializer = _compiler.GetSerializer<T>();
            if (serializer == null) return;
            foreach (var item in list.Cast<T>())
            {
                serializer(dataWriter, offsetWriter, item, offset);
            }
        }
    }
}