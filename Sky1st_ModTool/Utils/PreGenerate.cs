using Sky1st_ModTool.TBL.Model;
using System;
using System.Collections.Generic;

namespace Sky1st_ModTool.Utils
{
    public class PreGenerate
    {
        private static Dictionary<string, SpecialFieldTable> map = [];
        private static List<Type> types = [];
        //弃用
        private static void Initialize()
        {
            map["ItemTableData"] = new SpecialFieldTable
            {
                Fields =
                [
                    "Character",
                    "ItemKind",
                    "SubItemKind",
                    "Icon",
                    "Attr"
                ]
            };
        }
    }
}