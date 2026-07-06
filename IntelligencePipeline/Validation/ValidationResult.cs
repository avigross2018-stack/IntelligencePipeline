using System;


namespace IntelligencePipeline.Validation
{
    public class ValidationResult
    {
        public bool IsValid{ get;}
        public string ErrorMessage{ get; } 


        public ValidationResult(bool isValid, string errorMessage)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
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