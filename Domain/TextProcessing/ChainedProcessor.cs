using System.Collections.Generic;

namespace Domain.TextProcessing
{
    class ChainedProcessor : ITextProcessor
    {
        public ITextProcessor Next { get; }
        public ITextProcessor Inner { get; }

        public ChainedProcessor(ITextProcessor inner, ITextProcessor next)
        {
            Next = next;
            Inner = inner;
        }
        
        public IEnumerable<string> Execute(IEnumerable<string> text) => 
            Next.Execute(Inner.Execute(text));
    }
}