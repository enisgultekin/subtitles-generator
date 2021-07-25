using System.Collections.Generic;

namespace Domain
{
    public interface ITextWriter
    {
        void Write(IEnumerable<string> lines);
        void AppendLines(params string[] lines);
    }
}