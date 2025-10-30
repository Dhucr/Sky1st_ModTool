using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sky1st_ModTool.Utils
{
    public class ByteArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(byte[]);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // 反序列化时，可以保持为数组或根据需求处理
            if (reader.TokenType == JsonToken.StartArray)
            {
                var list = new List<byte>();
                while (reader.Read() && reader.TokenType != JsonToken.EndArray)
                {
                    if (reader.TokenType == JsonToken.Integer)
                    {
                        list.Add(Convert.ToByte(reader.Value));
                    }
                }
                return list.ToArray();
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var bytes = (byte[])value;

            writer.WriteStartArray();
            foreach (byte b in bytes)
            {
                writer.WriteValue(b);
            }
            writer.WriteEndArray();
        }
    }
}