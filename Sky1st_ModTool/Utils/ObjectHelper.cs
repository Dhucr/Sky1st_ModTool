using Sky1st_ModTool.TBL.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sky1st_ModTool.Utils
{
    public static class ObjectHelper
    {
        // 缓存 PropertyInfo 和类型检查结果
        private static readonly ConcurrentDictionary<(Type, string), FieldInfo[]> _fieldCache = new();

        /// <summary>
        /// 获取缓存键
        /// </summary>
        private static (Type, string) GetCacheKey(Type type, string operation)
        {
            return (type, operation);
        }

        /// <summary>
        /// 获取具有指定条件的 PropertyInfo 数组（带缓存）
        /// </summary>
        private static FieldInfo[] GetCachedFields(Type type, Func<FieldInfo, bool> predicate, string operation)
        {
            (Type, string) cacheKey = GetCacheKey(type, operation);
            return _fieldCache.GetOrAdd(cacheKey, _ =>
                type.GetFields()
                    .Where(predicate)
                    .OrderBy(f => f.GetCustomAttribute<FieldOrderAttribute>()?.Order)
                    .ToArray());
        }

        /// <summary>
        /// 获取所有属性
        /// </summary>
        public static IEnumerable<FieldInfo> GetAllFields(Type type)
        {
            return GetCachedFields(type, _ => true, "All");
        }

        /// <summary>
        /// 深度克隆对象
        /// </summary>
        public static object? DeepClone(object graph)
        {
            if (graph == null) return null;

            Type type = graph.GetType();
            var clone = Activator.CreateInstance(type);

            foreach (FieldInfo field in GetAllFields(type))
            {
                if (field.FieldType.IsArray)
                {
                    var array = (Array)field.GetValue(graph)!;
                    var newArray = Array.CreateInstance(field.FieldType.GetElementType()!, array.Length);

                    for (var i = 0; i < array.Length; i++)
                        newArray.SetValue(DeepClone(array.GetValue(i)!), i);

                    field.SetValue(clone, newArray);
                }
                else if (IsCustomType(field.FieldType))
                {
                    field.SetValue(clone, DeepClone(field.GetValue(graph)!));
                }
                else
                {
                    field.SetValue(clone, field.GetValue(graph));
                }
            }

            return clone;
        }

        /// <summary>
        /// 判断是否为自定义类型
        /// </summary>
        private static bool IsCustomType(Type type)
        {
            return !type.IsPrimitive && type != typeof(string) && !type.IsValueType;
        }
    }
}