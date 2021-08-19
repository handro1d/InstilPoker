using Instil.Poker.Core.Exceptions;
using Instil.Poker.Core.Interfaces;
using Instil.Poker.Core.Tests.Fakes;
using Instil.Poker.Core.Tests.Utils;
using Instil.Poker.Core.Text;
using Instil.Poker.Domain.Entities;
using Instil.Poker.Domain.Enums;
using Instil.Poker.Domain.Interfaces;
using Instil.Poker.Domain.Utils;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Instil.Poker.Core.Tests.Text
{
    [TestFixture]
    internal sealed class TextFileParserFixture
    {
        private IFileValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new FakeFileValidator().WithValidFile().Object;
        }

        [Test]
        public void ParseFile_ShouldThrowExceptionForInvalidFile()
        {
            var validator = new FakeFileValidator().WithValidFile(false);
            var parser = new TextFileParser(validator.Object);

            Assert.Throws<InvalidFileException>(() => parser.ParseFile("ImInvalid").ToList());
        }

        [Test]
        public void ParseFile_ShouldThrowExceptionForInvalidCard()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Three, CardSuit.Hearts),
                new Card(CardValue.Three, CardSuit.Hearts),
                new Card(CardValue.Three, CardSuit.Hearts),
                new Card(CardValue.Three, CardSuit.Hearts)
            };

            var pokerHand = new FakePokerHand().WithCards(cards);
            var fileContent = ConvertHandToFileContent(pokerHand.Object);
            var createdFilePath = CreateFile(fileContent, "5Z");

            var parser = new TextFileParser(_validator);
            Assert.Throws<InvalidCardInputException>(() => parser.ParseFile(createdFilePath).ToList());
        }

        [Test]
        public void ParseFile_ShouldParseHandSuccessfully()
        {
            var createdFilePath = CreateFile("2H 3H 4C 5D 6S");
            var parser = new TextFileParser(_validator);

            var result = parser.ParseFile(createdFilePath).ToList();
            Assert.AreEqual(1, result.Count);
        }

        /// <summary>
        /// Convert poker hand into valid file content.
        /// </summary>
        /// <param name="pokerHand"><see cref="Domain.Interefaces.IPokerHand"> representation to convert.</param>
        /// <returns>String representation of poker hand</returns>
        private static string ConvertHandToFileContent(IPokerHand pokerHand)
        {
            var cards = pokerHand.Cards.Select(card => $"{card.Value.GetDescription()}{card.Suit.GetDescription()}");
            return string.Join(" ", cards);
        }

        /// <summary>
        /// Create text file containing poker hand.
        /// </summary>
        /// <param name="pokerHands">Poker hand(s) to include in file.</param>
        /// <returns>Filepath of created file.</returns>
        private static string CreateFile(params IPokerHand[] pokerHands)
        {
            var fileContent = pokerHands.Select(pokerHand => ConvertHandToFileContent(pokerHand));

            return CreateFile(fileContent.ToArray());
        }

        private static string CreateFile(params string[] fileContent)
        {
            // Get file path
            var filePath = GetTestFilePath();

            // Create file
            using (var streamWriter = File.CreateText(filePath))
            {
                foreach (var line in fileContent)
                {
                    streamWriter.WriteLine(line);
                }
            }

            TestContext.Progress.WriteLine($"Created file: {filePath}");

            return filePath;
        }

        /// <summary>
        /// Construct file path based on the current test.
        /// </summary>
        /// <returns>Generated filepath in Assets folder.</returns>
        private static string GetTestFilePath()
        {
            var assetsPath = AssetUtils.GetAssetsPath();
            var currentTest = TestContext.CurrentContext.Test.MethodName;
            return Path.Combine(assetsPath, $"{currentTest}.txt");
        }
    }
}