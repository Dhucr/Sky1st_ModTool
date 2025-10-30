using System;

namespace Sky1st_ModTool.TBL.Model
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FieldOffsetAttribute(FieldType type) : Attribute
    {
        public FieldType Type { get; } = type;
    }
}