using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Sky1st_ModTool.TBL.Handler
{
    public class DynamicCompiledManager
    {
        private static readonly DynamicCompiledManager _instance = new();
        private readonly EnhancedCodeGenerator _codeGenerator = new();
        private readonly Dictionary<Type, Delegate> _deserializerCache = [];
        private readonly Dictionary<Type, Delegate> _serializerCache = [];
        public static DynamicCompiledManager Instance => _instance;

        public Func<BinaryReader, byte[], T>? GetDeserializer<T>() where T : new()
        {
            var type = typeof(T);
            return _deserializerCache.TryGetValue(type, out var del)
                ? (Func<BinaryReader, byte[], T>)del
                : null;
        }

        public Action<BinaryWriter, BinaryWriter, T, int>? GetSerializer<T>() where T : new()
        {
            var type = typeof(T);
            return _serializerCache.TryGetValue(type, out var del)
                ? (Action<BinaryWriter, BinaryWriter, T, int>)del
                : null;
        }

        public void CompileWithRoslyn(Type[] types)
        {
            var assemblyName = $"DynamicTBLHelper_{Guid.NewGuid():N}";
            var sourceCode = _codeGenerator.GenerateCode(types);
            var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);
            var references = GetRequiredMetadataReferences(types);
            var compilation = CreateCompilation(assemblyName, syntaxTree, references);
            using var memoryStream = new MemoryStream();
            var emitResult = compilation.Emit(memoryStream);
            if (!emitResult.Success)
            {
                var errorMessages = emitResult.Diagnostics
                    .Where(diagnostic => diagnostic.Severity == DiagnosticSeverity.Error)
                    .Select(diagnostic => $"{diagnostic.Id}: {diagnostic.GetMessage()}");

                throw new InvalidOperationException($"Compilation failed:\n{string.Join("\n", errorMessages)}");
            }
            memoryStream.Seek(0, SeekOrigin.Begin);
            var assembly = Assembly.Load(memoryStream.ToArray());

            CacheDelegates(types, assembly);
        }

        private static List<PortableExecutableReference> GetRequiredMetadataReferences(IEnumerable<Type> types)
        {
            var baseAssemblies = new[]
            {
                typeof(object).Assembly,
                typeof(BinaryReader).Assembly,
                typeof(Enumerable).Assembly,
                Assembly.GetExecutingAssembly()
            };
            var references = baseAssemblies
                .Select(assembly => MetadataReference.CreateFromFile(assembly.Location))
                .ToList();
            var typeAssemblies = types
                .Select(type => type.Assembly)
                .Distinct();

            references.AddRange(typeAssemblies.Select(assembly =>
                MetadataReference.CreateFromFile(assembly.Location)));
            var currentDomainAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => !assembly.IsDynamic && !string.IsNullOrEmpty(assembly.Location));

            references.AddRange(currentDomainAssemblies.Select(assembly =>
                MetadataReference.CreateFromFile(assembly.Location)));
            return references;
        }

        private static CSharpCompilation CreateCompilation(string assemblyName, SyntaxTree syntaxTree,
            List<PortableExecutableReference> references)
        {
            var compilationOptions = new CSharpCompilationOptions(
                OutputKind.DynamicallyLinkedLibrary,
                optimizationLevel: OptimizationLevel.Release,
                allowUnsafe: false);
            return CSharpCompilation.Create(
                assemblyName,
                [syntaxTree],
                references,
                compilationOptions);
        }

        private void CacheDelegates(Type[] types, Assembly assembly)
        {
            foreach (var type in types)
            {
                var helperType = assembly.GetType($"{type.Name}Helper");
                if (helperType == null) continue;
                CacheDeserializerDelegate(type, helperType);
                CacheSerializerDelegate(type, helperType);
            }
        }

        private void CacheDeserializerDelegate(Type type, Type helperType)
        {
            var deserializerMethod = helperType.GetMethod("DeSerialize",
                BindingFlags.Public | BindingFlags.Static);
            if (deserializerMethod == null) return;
            var delegateType = typeof(Func<,,>).MakeGenericType(
                typeof(BinaryReader), typeof(byte[]), type);

            _deserializerCache[type] = Delegate.CreateDelegate(delegateType, deserializerMethod);
        }

        private void CacheSerializerDelegate(Type type, Type helperType)
        {
            var serializerMethod = helperType.GetMethod("Serialize",
                BindingFlags.Public | BindingFlags.Static);
            if (serializerMethod == null) return;
            var delegateType = typeof(Action<,,,>).MakeGenericType(
                typeof(BinaryWriter), typeof(BinaryWriter), type, typeof(int));

            _serializerCache[type] = Delegate.CreateDelegate(delegateType, serializerMethod);
        }
    }
}