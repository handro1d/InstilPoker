using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Instil.Poker.Core.Exceptions;
using Instil.Poker.Core.Interfaces;
using Instil.Poker.Domain.Entities;
using Instil.Poker.Domain.Enums;
using Instil.Poker.Domain.Interfaces;
using Instil.Poker.Domain.Utils;

namespace Instil.Poker.Core.Text
{
    public sealed class TextFileParser : IFileParser
    {
        private IFileValidator _validator;

        private static IEnumerable<string> ValidCards => EnumUtility.GetAllDescriptions<CardValue>().Distinct();
        private static IEnumerable<string> ValidSuits => EnumUtility.GetAllDescriptions<CardSuit>().Distinct();

        public TextFileParser(IFileValidator validator)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public IEnumerable<IPokerHand> ParseFile(string filePath)
        {
            var validationResult = _validator.Validate(filePath, ".txt");

            if (!validationResult.Succeeded)
            {
                throw new InvalidFileException(validationResult.Error);
            }

            var validCards = string.Join(',', ValidCards);
            var validSuits = string.Join(',', ValidSuits);

            var validCardRegexString = $"(?<value>[{validCards}])(?<suit>[{validSuits}])";
            var validCardRegex = new Regex(validCardRegexString);
            var validityRegex = new Regex($"^({validCardRegexString}($|\\s)){{1,}}$");

            using (var reader = new StreamReader(filePath))
            {
                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLine().Trim();

                    // Check validity of line
                    if (!validityRegex.IsMatch(line))
                    {
                        throw new InvalidCardInputException(line);
                    }

                    var cards = new List<Card>();

                    var match = validCardRegex.Match(line);
                    while (match.Success)
                    {
                        var matchGroups = match.Groups;
                        var valueMatch = matchGroups["value"].Value;
                        var suitMatch = matchGroups["suit"].Value;

                        // Construct Card
                        var value = EnumUtility.TryGetFromDescription<CardValue>(valueMatch);
                        var suit = EnumUtility.TryGetFromDescription<CardSuit>(suitMatch);
                        var card = new Card(value, suit);

                        // Add Card to hand
                        cards.Add(card);

                        // Move onto the next card
                        match = match.NextMatch();
                    }

                    yield return new DefaultPokerHand(cards);
                }
            }
        }
    }
}