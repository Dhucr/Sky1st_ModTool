using System;

namespace Sky1st_ModTool.TBL.Model
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ArrayLengthAttribute : Attribute
    {
        public bool IsFieldName => LengthFieldName != null;
        public int Length { get; }
        public string? LengthFieldName { get; }

        public ArrayLengthAttribute(int length) => Length = length;

        public ArrayLengthAttribute(string lengthFieldName) => LengthFieldName = lengthFieldName;
    }
}