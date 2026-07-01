using System;


namespace IntelligencePipeline.Validation
{
    public class ValidationResult
    {
        private bool _isValid;
        public bool IsValid{ get;}

        private string _errorMessage;
        public string ErrorMessage{ get; } 


        public ValidationResult(bool isValid, string errorMessage)
        {
            _isValid = isValid;
            _errorMessage = errorMessage;
        }

        public static ValidationResult Success()
        {
            return new ValidationResult(true, string.Empty);
        }  

        public static ValidationResult Failure(string errorMessage)
        {
            return new ValidationResult(false, errorMessage);
        } 
    }
}