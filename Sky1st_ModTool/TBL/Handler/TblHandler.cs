using Sky1st_ModTool.TBL.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace Sky1st_ModTool.TBL.Handler
{
    public class TblHandler
    {
        private const string ExpectedMagicHeader = "#TBL";
        private const int NodeNameLength = 64;

        public TblFile ParseFile(string filePath)
        {
            using var fileStream = new FileStream(filePath, FileMode.Open);
            using var binaryReader = new BinaryReader(fileStream);

            return ParseFromReader(binaryReader, () =>
            {
                fileStream.Position = 0;
                return binaryReader.ReadBytes((int)fileStream.Length);
            });
        }

        public TblFile ParseData(byte[] fileData)
        {
            using var memoryStream = new MemoryStream(fileData);
            using var binaryReader = new BinaryReader(memoryStream);

            return ParseFromReader(binaryReader, () => fileData);
        }

        private TblFile ParseFromReader(BinaryReader reader, Func<byte[]> getRawData)
        {
            var tblFile = new TblFile();

            ValidateFileHeader(reader);
            tblFile.NodeCount = reader.ReadUInt32();

            var nodes = Enumerable.Range(0, (int)tblFile.NodeCount)
                .Select(_ => ParseNodeHeader(reader))
                .ToList();

            nodes.ForEach(tblFile.Nodes.Add);
            tblFile.RawData = getRawData();

            return tblFile;
        }

        private static void ValidateFileHeader(BinaryReader reader)
        {
            var magicHeader = Encoding.ASCII.GetString(reader.ReadBytes(4));
            if (magicHeader != ExpectedMagicHeader)
                throw new InvalidDataException("Invalid TBL file format");
        }

        private TblNode ParseNodeHeader(BinaryReader reader)
        {
            var nameBytes = reader.ReadBytes(NodeNameLength);
            var name = Encoding.ASCII.GetString(nameBytes).TrimEnd('\0');

            return new TblNode
            {
                Name = name,
                UnknownField = reader.ReadUInt32(),
                DataOffset = reader.ReadUInt32(),
                DataSize = reader.ReadUInt32(),
                DataCount = reader.ReadUInt32()
            };
        }

        public void SerializeHeader(BinaryWriter writer, ObservableCollection<TblNode> nodes)
        {
            WriteFileHeader(writer, nodes.Count);
            CalculateNodeOffsets(nodes);
            WriteNodeHeaders(writer, nodes);
        }

        private static void WriteFileHeader(BinaryWriter writer, int nodeCount)
        {
            writer.Write(Encoding.ASCII.GetBytes(ExpectedMagicHeader));
            writer.Write((uint)nodeCount);
        }

        private static void CalculateNodeOffsets(IEnumerable<TblNode> nodes)
        {
            const int baseHeaderSize = 8; // 4 bytes magic + 4 bytes node count
            var nodeHeaderSize = nodes.Count() * 80; // each node header is 80 bytes
            var totalHeaderSize = baseHeaderSize + nodeHeaderSize;

            var currentDataOffset = (uint)totalHeaderSize;

            foreach (var node in nodes)
            {
                node.DataOffset = currentDataOffset;
                currentDataOffset += (uint)(node.DataSize * node.DataCount);
            }
        }

        private static void WriteNodeHeaders(BinaryWriter writer, IEnumerable<TblNode> nodes)
        {
            foreach (var node in nodes)
            {
                SerializeNodeHeader(writer, node);
            }
        }

        private static void SerializeNodeHeader(BinaryWriter writer, TblNode node)
        {
            var nameBytes = new byte[NodeNameLength];
            var actualNameBytes = Encoding.ASCII.GetBytes(node.Name);
            Array.Copy(actualNameBytes, nameBytes, Math.Min(actualNameBytes.Length, NodeNameLength));

            writer.Write(nameBytes);
            writer.Write(node.UnknownField);
            writer.Write(node.DataOffset);
            writer.Write(node.DataSize);
            writer.Write(node.DataCount);
        }
    }
}