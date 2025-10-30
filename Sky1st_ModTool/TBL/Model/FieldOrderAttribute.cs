using System;

namespace Sky1st_ModTool.TBL.Model
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FieldOrderAttribute : Attribute
    {
        public int Order { get; }

        public FieldOrderAttribute(int order) => Order = order;
    }
}