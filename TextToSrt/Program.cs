using System;
using System.IO;
using System.Reflection;
using Domain;
using Domain.Models;
using Domain.TextProcessing.Implementation;

namespace SubtitlesConverter.Presentation
{
    class Program
    {
        private static string ToolName => Assembly.GetExecutingAssembly().GetName().Name;

        private static string UsageText =>
            $"{ToolName} <source file>.txt <output file>.srt ";

        static void ShowUsage() =>
            Console.WriteLine(UsageText);

        static bool Verify(string[] args) =>
            args.Length == 2 &&
            File.Exists(args[0]); 

        static void Process(FileInfo source, FileInfo destination)
        {
            try
            {
                Subtitles subtitles = new SubtitlesBuilder()
                    .For(new TextFileReader(source))
                    .Using(SpecialLettersFilter.ReplaceSpecialLetters())
                    .Using(LinesTrimmer.RemoveWhiteSpace())
                    .Using(new SentencesBreaker())
                    .Using(LinesTrimmer.RemoveLineEndings())
                    .Using(new LinesBreaker(95, 45))
                    .Build();

                ISubtitlesVisitor visitor = new SubtitlesToSrtWriter(new TextFileWriter(destination));
                subtitles.Accept(visitor);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error processing text : {e.Message}");
                throw;
            }
        }

        static void Main(string[] args)
        {
            if (Verify(args))
                Process(new FileInfo(args[0]), new FileInfo(args[1]));
            else
                ShowUsage();
        }
    }
}