namespace Instil.Poker.Core.Validation
{
    public sealed class ValidationResult
    {
        public string Error { get; private set; }
        public bool Succeeded { get; private set; }

        public ValidationResult(bool succeeded)
            : this(succeeded, null) { }

        public ValidationResult(bool succeeded, string error)
        {
            this.Succeeded = succeeded;
            this.Error = error;
        }

        public static ValidationResult Failed(string error)
        {
            return new ValidationResult(false, error);
        }

        public static ValidationResult Success()
        {
            return new ValidationResult(true);
        }
    }
}