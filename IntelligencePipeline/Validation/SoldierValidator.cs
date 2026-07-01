using System;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    public class SoldierValidator : BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            if(report is not SoldierReport soldierReport)
            {
                return ValidationResult.Failure("Report is not SoldierReport");
            }
            else if(soldierReport.SoldierName.Length < 2 || soldierReport.SoldierName.Length > 50)
            {
                return ValidationResult.Failure("Invalid Soldier Name Length");
            }else if(soldierReport.SoldierID.Length != 7)
            {
                return ValidationResult.Failure("Invalid Soldier ID Length");
            }else if(soldierReport.Unit.Length < 2 || soldierReport.Unit.Length > 50)
            {
                return ValidationResult.Failure("Invalid Soldier Unit Length");
            }else if(soldierReport.ConfidenceLevel < 1 || soldierReport.ConfidenceLevel > 5)
            {
                return ValidationResult.Failure("Invalid Soldier ConfidenceLevel:");
            }

            return ValidationResult.Success();
        }
    }
}