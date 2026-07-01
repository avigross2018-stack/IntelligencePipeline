using System;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    public class DroneValidator : BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            if(report is not DroneReport droneReport)
            {
                return ValidationResult.Failure("Report is not DroneReport");
            }
            else if(droneReport.Altitude < 100 || droneReport.Altitude > 10000)
            {
                return ValidationResult.Failure("Invalid Altitude");
            }
            else if(droneReport.ImageQuality < 1 || droneReport.ImageQuality > 100)
            {
                return ValidationResult.Failure("Invalid ImageQuality");
            }

            return ValidationResult.Success();
        }
    }
}