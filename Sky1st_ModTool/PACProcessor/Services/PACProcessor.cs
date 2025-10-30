using Sky1st_ModTool.Core.Models;
using Sky1st_ModTool.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky1st_ModTool.PACProcessor.Services
{
    public class PACProcessor : IPACProcessor
    {
        public async Task<PACFile> LoadAsync(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"PAC file not found: {filePath}");
            await using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using var reader = new BinaryReader(fileStream);
            var pacFile = new PACFile { FilePath = filePath };

            // 读取头部
            pacFile.Header = ReadHeader(reader);

            // 读取文件条目
            var entries = ReadFileEntries(reader, pacFile.Header.FileCount);

            // 读取文件名和文件数据
            await ReadFileNameAsync(reader, entries);

            foreach (var entry in entries)
                pacFile.Entries.Add(entry);
            pacFile.IsLoaded = true;
            return pacFile;
        }

        private PACHeader ReadHeader(BinaryReader reader)
        {
            var magicBytes = reader.ReadBytes(4);
            var magic = Encoding.ASCII.GetString(magicBytes);

            if (magic != "FPAC")
                throw new InvalidDataException("Invalid PAC file format");
            return new PACHeader
            {
                Magic = magic,
                FileCount = reader.ReadUInt32(),
                FirstFileAddress = reader.ReadUInt32(),
                UnknownMagic = reader.ReadUInt32()
            };
        }

        private List<PACEntry> ReadFileEntries(BinaryReader reader, uint fileCount)
        {
            var entries = new List<PACEntry>();

            for (int i = 0; i < fileCount; i++)
            {
                var entry = new PACEntry
                {
                    FilenameCRC32 = reader.ReadUInt32(),
                    Padding = reader.ReadUInt32(),
                    FilenameStringAddress = reader.ReadUInt64(),
                    FileSize = reader.ReadUInt64(),
                    FileDataAddress = reader.ReadUInt64()
                };
                entries.Add(entry);
            }

            return entries;
        }

        private async Task ReadFileNameAsync(BinaryReader reader, List<PACEntry> entries)
        {
            foreach (var entry in entries)
            {
                // 读取文件名
                reader.BaseStream.Seek((long)entry.FilenameStringAddress, SeekOrigin.Begin);
                entry.Filename = ReadNullTerminatedString(reader);

                // 验证CRC32
                byte[] filenameBytes = Encoding.UTF8.GetBytes(entry.Filename);
                uint calculatedCrc32 = Crc32.ComputeChecksum(filenameBytes);
                uint expectedCrc = calculatedCrc32 ^ 0xFFFFFFFFu;

                if (entry.FilenameCRC32 != expectedCrc)
                    throw new InvalidDataException($"CRC32 mismatch for file: {entry.Filename}");
            }
        }

        private string ReadNullTerminatedString(BinaryReader reader)
        {
            var bytes = new List<byte>();
            byte current;

            while ((current = reader.ReadByte()) != 0)
                bytes.Add(current);

            return Encoding.UTF8.GetString(bytes.ToArray());
        }

        public async Task SaveAsync(PACFile pacFile, string outputPath)
        {
            // 实现保存逻辑（后续阶段）
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public IReadOnlyList<PACEntry> GetEntries(PACFile pacFile)
        {
            return pacFile.Entries.ToList();
        }

        public PACEntry? FindEntry(PACFile pacFile, string filename)
        {
            return pacFile.Entries.FirstOrDefault(e =>
                e.Filename.Equals(filename, StringComparison.OrdinalIgnoreCase));
        }

        // <summary>
        /// 根据PACEntry获取文件数据
        /// </summary>
        /// <param name="pacFile">PAC文件</param>
        /// <param name="entry">文件条目</param>
        /// <returns>文件数据的字节数组</returns>
        public async Task<byte[]> GetFileDataAsync(PACFile pacFile, PACEntry entry)
        {
            if (pacFile == null)
                throw new ArgumentNullException(nameof(pacFile));

            if (entry == null)
                throw new ArgumentNullException(nameof(entry));

            if (!File.Exists(pacFile.FilePath))
                throw new FileNotFoundException($"PAC file not found: {pacFile.FilePath}");
            await using var fileStream = new FileStream(pacFile.FilePath, FileMode.Open, FileAccess.Read);
            using var reader = new BinaryReader(fileStream);
            // 定位到文件数据位置
            reader.BaseStream.Seek((long)entry.FileDataAddress, SeekOrigin.Begin);

            // 读取文件数据
            return reader.ReadBytes((int)entry.FileSize);
        }

        /// <summary>
        /// 根据文件名获取文件数据
        /// </summary>
        /// <param name="pacFile">PAC文件</param>
        /// <param name="filename">完整文件名（包含路径）</param>
        /// <returns>文件数据的字节数组</returns>
        public async Task<byte[]> GetFileDataAsync(PACFile pacFile, string filename)
        {
            var entry = FindEntry(pacFile, filename);
            if (entry == null)
                throw new FileNotFoundException($"File not found in PAC: {filename}");
            return await GetFileDataAsync(pacFile, entry);
        }

        /// <summary>
        /// 导出文件到指定目录
        /// </summary>
        /// <param name="pacFile">PAC文件</param>
        /// <param name="entry">文件条目</param>
        /// <param name="outputDirectory">输出目录</param>
        /// <param name="preserveDirectoryStructure">是否保持目录结构</param>
        /// <returns>导出文件的完整路径</returns>
        public async Task<string> ExportFileAsync(PACFile pacFile, PACEntry entry, string outputDirectory, bool preserveDirectoryStructure = true)
        {
            if (!Directory.Exists(outputDirectory))
                Directory.CreateDirectory(outputDirectory);
            // 获取文件数据
            var fileData = await GetFileDataAsync(pacFile, entry);
            // 构建输出路径
            string outputPath;
            if (preserveDirectoryStructure)
            {
                // 保持原始目录结构
                var fullPath = entry.Filename;
                outputPath = Path.Combine(outputDirectory, fullPath);

                // 确保目标目录存在
                var directory = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
            }
            else
            {
                // 只使用文件名，忽略路径
                var fileName = Path.GetFileName(entry.Filename);
                if (string.IsNullOrEmpty(fileName))
                    fileName = $"unknown_{entry.FilenameCRC32:X8}";

                outputPath = Path.Combine(outputDirectory, fileName);
            }
            // 写入文件
            await File.WriteAllBytesAsync(outputPath, fileData);
            return outputPath;
        }

        /// <summary>
        /// 根据文件名导出文件
        /// </summary>
        /// <param name="pacFile">PAC文件</param>
        /// <param name="filename">完整文件名</param>
        /// <param name="outputDirectory">输出目录</param>
        /// <param name="preserveDirectoryStructure">是否保持目录结构</param>
        /// <returns>导出文件的完整路径</returns>
        public async Task<string> ExportFileAsync(PACFile pacFile, string filename, string outputDirectory, bool preserveDirectoryStructure = true)
        {
            var entry = FindEntry(pacFile, filename);
            if (entry == null)
                throw new FileNotFoundException($"File not found in PAC: {filename}");
            return await ExportFileAsync(pacFile, entry, outputDirectory, preserveDirectoryStructure);
        }

        /// <summary>
        /// 批量导出文件
        /// </summary>
        /// <param name="pacFile">PAC文件</param>
        /// <param name="outputDirectory">输出目录</param>
        /// <param name="preserveDirectoryStructure">是否保持目录结构</param>
        /// <param name="progress">进度回调</param>
        /// <returns>导出成功的文件列表</returns>
        public async Task<List<string>> ExportAllFilesAsync(PACFile pacFile, string outputDirectory,
            bool preserveDirectoryStructure = true, IProgress<ExportProgress>? progress = null)
        {
            var exportedFiles = new List<string>();
            var totalFiles = pacFile.Entries.Count;
            var current = 0;
            foreach (var entry in pacFile.Entries)
            {
                try
                {
                    var exportedPath = await ExportFileAsync(pacFile, entry, outputDirectory, preserveDirectoryStructure);
                    exportedFiles.Add(exportedPath);

                    current++;
                    progress?.Report(new ExportProgress
                    {
                        CurrentFile = entry.Filename,
                        CurrentIndex = current,
                        TotalFiles = totalFiles,
                        Percentage = (double)current / totalFiles * 100
                    });
                }
                catch (Exception ex)
                {
                    // 记录错误但继续处理其他文件
                    Console.WriteLine($"Error exporting file {entry.Filename}: {ex.Message}");
                }
            }
            return exportedFiles;
        }
    }

    /// <summary>
    /// 导出进度信息
    /// </summary>
    public class ExportProgress
    {
        public string CurrentFile { get; set; } = string.Empty;
        public int CurrentIndex { get; set; }
        public int TotalFiles { get; set; }
        public double Percentage { get; set; }
    }

    // CRC32 计算器
    public static class Crc32
    {
        private static readonly uint[] Table;

        static Crc32()
        {
            Table = new uint[256];
            for (uint i = 0; i < 256; i++)
            {
                uint temp = i;
                for (int j = 8; j > 0; j--)
                {
                    if ((temp & 1) == 1)
                        temp = (temp >> 1) ^ 0xEDB88320u;
                    else
                        temp >>= 1;
                }
                Table[i] = temp;
            }
        }

        public static uint ComputeChecksum(byte[] bytes)
        {
            uint crc = 0xFFFFFFFF;
            for (int i = 0; i < bytes.Length; i++)
            {
                byte index = (byte)((crc & 0xFF) ^ bytes[i]);
                crc = (crc >> 8) ^ Table[index];
            }
            return crc ^ 0xFFFFFFFF;
        }
    }
}