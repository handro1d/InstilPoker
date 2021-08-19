using System.Collections.Generic;
using Instil.Poker.Domain.Interfaces;

namespace Instil.Poker.Core.Interfaces
{
    public interface IFileParser
    {
        /// <summary>
        /// Read and parse Poker Hand(s) from file
        /// </summary>
        /// <param name="filePath">Path of file to read.</param>
        /// <returns>IEnumerable of <see cref="Instil.Poker.Domain.Interfaces.IPokerHand"> of parsed hands.</returns>
        IEnumerable<IPokerHand> ParseFile(string filePath);
    }
}