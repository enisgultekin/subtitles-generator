using System.Collections.Generic;

namespace Domain.TextProcessing.Implementation.Splitters
{
    internal class PassThroughSplitter : ITwoWaySplitter
    {
        public IEnumerable<(string left, string right)> ApplyTo(string line) =>
            new[] {(line, string.Empty)};
    }
}
