using System.Collections.Generic;
using System.Linq;

namespace Domain.TextProcessing.Implementation.Splitters
{
    internal class AppendSplitter : ITwoWaySplitter
    {
        private ITwoWaySplitter Head { get; }
        private ITwoWaySplitter Tail { get; }

        public AppendSplitter(ITwoWaySplitter head, ITwoWaySplitter tail)
        {
            this.Head = head;
            this.Tail = tail;
        }

        public IEnumerable<(string left, string right)> ApplyTo(string line) =>
            this.Head.ApplyTo(line)
                .Concat(this.Tail.ApplyTo(line));
    }
}
