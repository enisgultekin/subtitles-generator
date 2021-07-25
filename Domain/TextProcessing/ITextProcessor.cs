using System.Collections.Generic;

namespace Domain.TextProcessing
{
    public interface ITextProcessor
    {
        IEnumerable<string> Execute(IEnumerable<string> text);
    }
}