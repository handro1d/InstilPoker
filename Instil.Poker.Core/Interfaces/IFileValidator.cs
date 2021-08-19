using Instil.Poker.Core.Validation;

namespace Instil.Poker.Core.Interfaces
{
    public interface IFileValidator
    {
        /// <summary>
        /// Validate existence of provided file path.
        /// </summary>
        /// <param name="filePath">File path to validate.</param>
        /// <param name="validFileTypes">Valid file types, if there are restrictions.</param>
        /// <returns><see cref="Instil.Poker.Core.Validation.ValidationResult"> indicating validity of provided file path.</returns>
        ValidationResult Validate(string filePath, params string[] validFileTypes);
    }
}