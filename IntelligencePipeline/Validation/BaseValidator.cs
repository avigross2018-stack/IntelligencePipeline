using System;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    public abstract class BaseValidator : IValidator
    {
        public ValidationResult Validate(Report report)
        {
            var commonResult = ValidateCommonFields(report);
            if (!commonResult.IsValid)
            {
                return commonResult;
            }
            else
            {
                return ValidateSpecificFields(report);
            }
        }

        protected ValidationResult ValidateCommonFields(Report report)
        {
            if(report.Timestamp > DateTime.Now ||
                report.Timestamp < new DateTime(2020, 01, 01))
            {
                return ValidationResult.Failure("Invalid DateTime");
            }
            else if(report.Latitude < 29.5000 || report.Latitude > 33.5000)
            {
                return ValidationResult.Failure("Invalid Latitude");
            }
            else if(report.Longitude < 34.0000 || report.Longitude > 36.0000)
            {
                return ValidationResult.Failure("Invalid Longitude");
            }
            else if(report.Description.Length < 10 || report.Description.Length > 500)
            {
                return ValidationResult.Failure("Invalid Description");
            }
            else
            {
                return ValidationResult.Success();
            }
        }

        protected abstract ValidationResult ValidateSpecificFields(Report report);


    }
}