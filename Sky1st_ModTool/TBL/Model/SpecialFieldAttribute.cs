using System;

namespace Sky1st_ModTool.TBL.Model
{
    [AttributeUsage(AttributeTargets.Field)]
    public class SpecialFieldAttribute(SpecialFieldType type) : Attribute
    {
        public SpecialFieldType Type { get; } = type;
    }
}