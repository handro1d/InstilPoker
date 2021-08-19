using Instil.Poker.Console.Utils;
using Instil.Poker.Core.Interfaces;
using Instil.Poker.Domain.Interfaces;
using System;
using System.Linq;

namespace Instil.Poker.Console
{
    public sealed class AppHost : IAppHost
    {
        private readonly IFileParser _fileParser;
        private readonly IPokerHandDetermination _pokerHandDetermination;

        public AppHost(IPokerHandDetermination pokerHandDetermination, IFileParser fileParser)
        {
            _pokerHandDetermination = pokerHandDetermination ?? throw new ArgumentNullException(nameof(pokerHandDetermination));
            _fileParser = fileParser ?? throw new ArgumentNullException(nameof(fileParser));
        }

        public void Run(params string[] args)
        {
            ColourConsole.WriteLine("Welcome to POKER FACE!", ConsoleColor.DarkMagenta);

            try
            {
                // Read hand
                var filePath = ColourConsole.ReadLine("File path: ", ConsoleColor.Yellow);
                var pokerHands = _fileParser.ParseFile(filePath);

                // Determine poker hand(s)
                for (int i = 0; i < pokerHands.Count(); i++)
                {
                    OutputPokerHand(i + 1, pokerHands.ElementAt(i));
                }
            }
            catch (Exception ex)
            {
                ColourConsole.WriteLine($"Exception: {ex.Message}", ConsoleColor.Red);
            }

            ColourConsole.WriteLine("Press any key to exit", ConsoleColor.Yellow);
            System.Console.ReadKey(true);
        }

        private void OutputPokerHand(int handNumber, IPokerHand pokerHand)
        {
            var result = _pokerHandDetermination.DetermineHand(pokerHand);
            var output = $"Hand {handNumber}: {result}";

            ColourConsole.WriteLine(output, ConsoleColor.Green);
        }
    }
}