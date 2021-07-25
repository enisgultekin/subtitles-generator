using System.Collections.Generic;
using System.Linq;

namespace Domain.TextProcessing.Implementation.LineProcessing
{
    internal class LineRepeater : ITextProcessor
    {
        private ILineProcessor LineProcessor { get; }
     
        public LineRepeater(ILineProcessor lineProcessor)
        {
            this.LineProcessor = lineProcessor;
        }

        public IEnumerable<string> Execute(IEnumerable<string> text) =>
            text.SelectMany(this.LineProcessor.Execute);
    }
}
