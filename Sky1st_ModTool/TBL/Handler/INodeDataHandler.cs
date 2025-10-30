using Sky1st_ModTool.TBL.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sky1st_ModTool.TBL.Handler
{
    public interface INodeDataHandler
    {
        bool CanParse(string nodeName);

        object? Parse(TblNode node, byte[] fileData);

        void Serialize(BinaryWriter dataWriter, BinaryWriter offsetWriter, object list, string nodeName, int offset);
    }

    public class NodeDataParserFactory
    {
        private readonly List<INodeDataHandler> _parsers = new();

        public void RegisterParser(INodeDataHandler parser) => _parsers.Add(parser);

        public INodeDataHandler? GetParser(string nodeName) =>
            _parsers.FirstOrDefault(parser => parser.CanParse(nodeName));
    }
}