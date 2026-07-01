using System;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    public class RadarValidator : BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            if(report is not RadarReport radarReport)
            {
                return ValidationResult.Failure("Report is not RadarReport");
            }
            else if(radarReport.Speed < 0 || radarReport.Speed > 2000)
            {
                return ValidationResult.Failure("Invalid Speed");
            }else if(radarReport.Direction < 0 || radarReport.Direction > 360)
            {
                return ValidationResult.Failure("Invalid Direction");
            }else if(radarReport.Distance < 100 || radarReport.Distance > 100_000)
            {
                return ValidationResult.Failure("Invalid Distance");
            }

            return ValidationResult.Success();
        }
    }
}