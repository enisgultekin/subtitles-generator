using System.Collections.Generic;

namespace Domain.TextProcessing.Implementation
{
    interface ILineProcessor
    {
        IEnumerable<string> Execute(string line);
    }
}
