using System;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Models.Enums;

namespace IntelligencePipeline.Validation
{
    public class SignalValidator : BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            if(report is not SignalReport signalReport)
            {
                return ValidationResult.Failure("Report is not SignalReport");
            }
            else if(signalReport.Frequency < 1 || signalReport.Frequency > 3000)
            {
                return ValidationResult.Failure("Invalid Frequency");
            }else if(signalReport.Content.Length < 5 || signalReport.Content.Length > 1000)
            {
                return ValidationResult.Failure("Invalid Content Length");
            }else if(!Enum.IsDefined(typeof(Language), signalReport.Language))
            {
                return ValidationResult.Failure("Invalid Language");
            }
            else if(signalReport.SignalStrength < -120 || signalReport.SignalStrength > 0)
            {
                return ValidationResult.Failure("Invalid SignalStrength");
            }

            return ValidationResult.Success();
        }
    }
}