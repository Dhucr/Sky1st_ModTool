using Sky1st_ModTool.TBL.Model;
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sky1st_ModTool.TBL.Handler
{
    public class EnhancedCodeGenerator
    {
        public string GenerateDrCode(Type dataType)
        {
            var sb = new StringBuilder();
            sb.AppendLine(GenerateUsingSection());
            sb.AppendLine(GenerateClassSection(dataType, dataType.Name));
            sb.AppendLine(GenerateHelperMethods());
            return sb.ToString();
        }

        private FieldInfo[]? fieldInfos;

        public string GenerateCode(Type[] types)
        {
            var sb = new StringBuilder();
            sb.AppendLine(GenerateUsingSection());
            foreach (var type in types)
            {
                fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
                sb.AppendLine(GenerateClassSection(type, type.Name));
                sb.AppendLine();
            }
            sb.AppendLine(GenerateHelperMethods());

            return sb.ToString();
        }

        private string GenerateUsingSection()
        {
            return @"using System;
using System.IO;
using System.Collections.Generic;
using Sky1st_ModTool.TBL.Nodes;

";
        }

        private string GenerateClassSection(Type dataType, string className)
        {
            var sb = new StringBuilder();

            var fields = dataType.GetFields(BindingFlags.Public | BindingFlags.Instance)
                .OrderBy(f => f.GetCustomAttribute<FieldOrderAttribute>()?.Order ?? 0)
                .ToArray();

            sb.AppendLine($@"public static class {className}Helper
{{
    public static {className} DeSerialize(BinaryReader br, byte[] fileData)
    {{
        var obj = new {className}();");

            // 生成字段反序列化代码
            foreach (var field in fields)
            {
                sb.AppendLine(GenerateDeSerializeFieldCode(field, "obj"));
            }

            sb.AppendLine(@"        return obj;
    }
");
            sb.AppendLine($"    public static void Serialize(BinaryWriter bwData, BinaryWriter bwOffset, {className} obj, int offset) ");
            sb.AppendLine("    {");

            // 生成字段序列化代码
            foreach (var field in fields)
            {
                sb.AppendLine(GenerateSerializeFieldCode(field, "obj"));
            }
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }

        /*
        private string GenerateFieldsCode(Type dataType, string target, Func<FieldInfo, string, string> func)
        {
            var sb = new StringBuilder();

            var fields = dataType.GetFields(BindingFlags.Public | BindingFlags.Instance)
                .OrderBy(f => f.GetCustomAttribute<FieldOrderAttribute>()?.Order ?? 0)
                .ToArray();

            foreach (var field in fields)
            {
                sb.AppendLine(func(field, target));
            }

            return sb.ToString();
        }*/

        private string GenerateSerializeFieldCode(FieldInfo field, string target)
        {
            if (IsOffsetField(field))
            {
                return GenerateSerializeOffsetFieldCode(field, target);
            }
            else if (field.FieldType.IsArray)
            {
                return GenerateSerializePrimitiveArrayCode(field, target);
            }
            else if (field.FieldType.IsClass && field.FieldType != typeof(string))
            {
                return GenerateSerializeClassCode(field, target);
            }
            else
            {
                return GenerateSerializePrimitiveCode(field, target);
            }
        }

        private string GenerateSerializeOffsetFieldCode(FieldInfo field, string target)
        {
            var offsetAttr = field.GetCustomAttribute<FieldOffsetAttribute>();
            var sb = new StringBuilder();
            sb.AppendLine("        bwData.Write((ulong)(offset + bwOffset.BaseStream.Position));");

            switch (offsetAttr?.Type)
            {
                case FieldType.String:
                    sb.Append($@"        OffsetHelpers.WriteOffsetString(bwOffset, {target}.{field.Name});");
                    break;

                case FieldType.Array:
                    sb.Append(GenerateSerializeOffsetArrayCode(field, target));
                    break;

                default:
                    throw new NotSupportedException($"Unsupported offset type: {offsetAttr?.Type}");
            }
            ;

            return sb.ToString();
        }

        private string GenerateSerializeOffsetArrayCode(FieldInfo field, string target)
        {
            var arrayLengthAttr = field.GetCustomAttribute<ArrayLengthAttribute>();
            if (arrayLengthAttr == null)
            {
                throw new InvalidOperationException($"Array field {field.Name} must have ArrayLengthAttribute");
            }

            string elementType = GetElementTypeName(field.FieldType);

            return $@"        foreach (var item in {target}.{field.Name})
        {{
            bwOffset.Write(item);
        }}";
        }

        private string GenerateSerializePrimitiveArrayCode(FieldInfo field, string target)
        {
            var arrayLengthAttr = field.GetCustomAttribute<ArrayLengthAttribute>();
            if (arrayLengthAttr == null)
            {
                throw new InvalidOperationException($"Array field {field.Name} must have ArrayLengthAttribute");
            }
            string writeMethod = GetWriteMethodForType(field, target);
            return $@"        foreach (var item in {target}.{field.Name})
        {{
    {writeMethod}
        }}";
        }

        public string GenerateSerializeClassCode(FieldInfo field, string target)
        {
            return $"        {field.FieldType.Name}Helper.Serialize(bwData, bwOffset, {target}.{field.Name}, offset);";
        }

        public string GenerateSerializeClassCode(Type type, string target)
        {
            return $"        {type.Name}Helper.Serialize(bwData, bwOffset, {target}, offset);";
        }

        public string GenerateSerializePrimitiveCode(FieldInfo field, string target)
        {
            return $"        bwData.Write({target}.{field.Name});";
        }

        private string GetWriteMethodForType(FieldInfo field, string target)
        {
            var type = field.FieldType.GetElementType();
            if (type!.IsClass && type != typeof(string))
            {
                return GenerateSerializeClassCode(type, "item");
            }
            return $"        bwData.Write(item);";
        }

        private string GenerateDeSerializeFieldCode(FieldInfo field, string target)
        {
            if (IsOffsetField(field))
            {
                return GenerateDeSerializeOffsetFieldCode(field, target);
            }
            else if (field.FieldType.IsArray)
            {
                return GeneratePrimitiveArrayCode(field, target);
            }
            else if (field.FieldType.IsClass && field.FieldType != typeof(string))
            {
                return GenerateClassCode(field, target);
            }
            else
            {
                return GeneratePrimitiveCode(field, target);
            }
        }

        private bool IsOffsetField(FieldInfo field)
        {
            return field.GetCustomAttribute<FieldOffsetAttribute>() != null;
        }

        private string GenerateDeSerializeOffsetFieldCode(FieldInfo field, string target)
        {
            var offsetAttr = field.GetCustomAttribute<FieldOffsetAttribute>();

            return offsetAttr.Type switch
            {
                FieldType.String => $@"        {target}.{field.Name} = OffsetHelpers.ReadOffsetString(br, fileData, br.ReadUInt64());",
                FieldType.Array => GenerateDeSerializeOffsetArrayCode(field, target),
                _ => throw new NotSupportedException($"Unsupported offset type: {offsetAttr.Type}")
            };
        }

        private string GenerateDeSerializeOffsetArrayCode(FieldInfo field, string target)
        {
            var arrayLengthAttr = field.GetCustomAttribute<ArrayLengthAttribute>();
            if (arrayLengthAttr == null || !arrayLengthAttr.IsFieldName)
            {
                throw new InvalidOperationException($"Array field {field.Name} must have ArrayLengthAttribute");
            }

            var lenName = arrayLengthAttr.LengthFieldName;
            var typeName = fieldInfos?.FirstOrDefault(f => f.Name == lenName)?.FieldType.Name;

            string elementType = GetElementTypeName(field.FieldType);

            return $@"        var offset{lenName} = br.ReadUInt64();
        var pos{lenName} = br.BaseStream.Position;
        var length{lenName} = br.{GetReadMethod(typeName!)};
        br.BaseStream.Position = pos{lenName};
        {target}.{field.Name} = OffsetHelpers.ReadOffsetArray<{elementType}>(br, fileData, offset{lenName}, (int)length{lenName});";
        }

        private string GeneratePrimitiveArrayCode(FieldInfo field, string target)
        {
            var arrayLengthAttr = field.GetCustomAttribute<ArrayLengthAttribute>();
            if (arrayLengthAttr == null)
            {
                throw new InvalidOperationException($"Array field {field.Name} must have ArrayLengthAttribute");
            }

            string lengthCode = arrayLengthAttr.IsFieldName ?
                $"{target}.{arrayLengthAttr.LengthFieldName}" :
                arrayLengthAttr.Length.ToString();

            string elementType = GetElementTypeName(field.FieldType);
            string readMethod = GetReadMethodForType(field.FieldType.GetElementType());

            return $@"        {target}.{field.Name} = new {elementType}[{lengthCode}];
        for (int i = 0; i < {lengthCode}; i++)
        {{
            {target}.{field.Name}[i] = {readMethod};
        }}";
        }

        private string GenerateClassCode(FieldInfo field, string target)
        {
            var sb = new StringBuilder();

            sb.AppendLine($@"
        {target}.{field.Name} = new {field.FieldType.Name}();");

            // 递归生成嵌套类的字段代码
            sb.Append(GenerateDeSerializeFieldCode(field, $"{target}.{field.Name}"));

            return sb.ToString();
        }

        private string GeneratePrimitiveCode(FieldInfo field, string target)
        {
            return $"        {target}.{field.Name} = br.{GetReadMethod(field.FieldType.Name)};";
        }

        private string GetReadMethod(string typeName)
        {
            return typeName switch
            {
                "Int64" or "long" => "ReadInt64()",
                "UInt64" or "ulong" => "ReadUInt64()",
                "Int32" or "int" => "ReadInt32()",
                "UInt32" or "uint" => "ReadUInt32()",
                "Int16" or "short" => "ReadInt16()",
                "UInt16" or "ushort" => "ReadUInt16()",
                "Single" or "float" => "ReadSingle()",
                "Double" or "double" => "ReadDouble()",
                "Byte" or "byte" => "ReadByte()",
                "SByte" or "sbyte" => "ReadSByte()",
                "Boolean" or "bool" => "ReadBoolean()",
                "Char" or "char" => "ReadChar()",
                _ => throw new NotSupportedException($"Unsupported type: {typeName}")
            };
        }

        private string GetReadMethodForType(Type type)
        {
            if (type.IsClass && type != typeof(string))
            {
                return $"{type.Name}Helper.DeSerialize(br, fileData)";
            }
            return $"br.{GetReadMethod(type.Name)}";
        }

        private string GetElementTypeName(Type arrayType)
        {
            var elementType = arrayType.GetElementType();
            return elementType?.Name ?? "object";
        }

        private string GenerateHelperMethods()
        {
            return @"
public static class OffsetHelpers{
    public static void WriteOffsetString(BinaryWriter bwOffset, string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            bwOffset.Write((byte)0);
            return;
        }

        var bytes = System.Text.Encoding.UTF8.GetBytes(value);
        bwOffset.Write(bytes);
        bwOffset.Write((byte)0); // Null-terminator
    }

    public static string ReadOffsetString(BinaryReader br, byte[] fileData, ulong offset)
    {
        if (offset >= (ulong)fileData.Length) return string.Empty;
        var chars = new List<byte>();
        for (ulong i = offset; i < (ulong)fileData.Length && fileData[i] != 0; i++)
        {
            chars.Add(fileData[i]);
        }
        return System.Text.Encoding.UTF8.GetString(chars.ToArray());
    }

    public static T[] ReadOffsetArray<T>(BinaryReader br, byte[] fileData, ulong offset, int length)
    {
        if (offset >= (ulong)fileData.Length) return new T[0];
        var result = new T[length];
        using var stream = new MemoryStream(fileData);
        using var arrayReader = new BinaryReader(stream);
        stream.Position = (long)offset;

        for (int i = 0; i < length; i++)
        {
            result[i] = ReadPrimitive<T>(arrayReader);
        }
        return result;
    }

    public static T ReadPrimitive<T>(BinaryReader reader)
    {
        return typeof(T).Name switch
        {
            ""Int32"" => (T)(object)reader.ReadInt32(),
            ""UInt32"" => (T)(object)reader.ReadUInt32(),
            ""Int16"" => (T)(object)reader.ReadInt16(),
            ""UInt16"" => (T)(object)reader.ReadUInt16(),
            ""Int64"" => (T)(object)reader.ReadInt64(),
            ""UInt64"" => (T)(object)reader.ReadUInt64(),
            ""Single"" => (T)(object)reader.ReadSingle(),
            ""Double"" => (T)(object)reader.ReadDouble(),
            ""Byte"" => (T)(object)reader.ReadByte(),
            ""SByte"" => (T)(object)reader.ReadSByte(),
            ""Boolean"" => (T)(object)reader.ReadBoolean(),
            ""Char"" => (T)(object)reader.ReadChar(),
            _ => throw new NotSupportedException($""Unsupported primitive type: {typeof(T).Name}"")
        };
    }
}";
        }
    }
}