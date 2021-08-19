using System.IO;
using System.Linq;
using Instil.Poker.Core.Interfaces;

namespace Instil.Poker.Core.Validation
{ 
    public sealed class WindowsFileValidator : IFileValidator
    {
        public ValidationResult Validate(string filePath, params string[] validFileTypes)
        {
            if (!File.Exists(filePath))
            {
                return ValidationResult.Failed("File does not exist");
            }

            if (!IsValidFileType(filePath, validFileTypes))
            {
                return ValidationResult.Failed("File is not the expected type");
            }

            return ValidationResult.Success();
        }

        private bool IsValidFileType(string filePath, string[] validFileTypes)
        {
            var fileType = Path.GetExtension(filePath);
            return validFileTypes.Contains(fileType);
        }
    }
}