using System.Collections.Generic;
using SubtitlesConverter.Common;

namespace Domain.TextProcessing.Implementation.Splitters
{
    internal class ShortestLeftWins : ITwoWaySplitter
    {
        private ITwoWaySplitter Splitter { get; }
     
        public ShortestLeftWins(ITwoWaySplitter splitter)
        {
            this.Splitter = splitter;
        }

        public IEnumerable<(string left, string right)> ApplyTo(string line) => 
            this.Splitter.ApplyTo(line)
                .WithMinimumOrEmpty(tuple => tuple.left.Length);
    }
}