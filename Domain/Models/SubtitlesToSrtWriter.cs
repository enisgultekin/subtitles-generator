namespace Domain.Models
{
    public class SubtitlesToSrtWriter : ISubtitlesVisitor
    {
        private ITextWriter Destination { get; }
        private int LastOrdinal { get; set; }
        
        public SubtitlesToSrtWriter(ITextWriter destination)
        {
            Destination = destination;
            LastOrdinal = 0;
        }
        
        public void Visit(SubtitleLine line)
        {
            LastOrdinal += 1;
            Destination.AppendLines(
                $"{LastOrdinal + 1}",
                $"{line.BeginOffset:hh\\:mm\\:ss\\,fff} --> {line.EndOffset:hh\\:mm\\:ss\\,fff}",
                $"{line.Content}",
                string.Empty
            );
        }
    }
}