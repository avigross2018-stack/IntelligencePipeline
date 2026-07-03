using System;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Storage;
using IntelligencePipeline.Validation;
using IntelligencePipeline.Calculators;

namespace IntelligencePipeline.Pipeline
{
    public class ReportPipeline
    {
        private ReportRepository _validatedReports;
        private RejectedReportRepository _rejectedReports;

        private ReliabilityCalculator _reliabilityCalculator;
        private PriorityCalculator _priorityCalculator;
        private ClassificationCalculator _classificationCalculator;

        public ReportPipeline()
        {
            _validatedReports = new ReportRepository();
            _rejectedReports = new RejectedReportRepository();

            _reliabilityCalculator = new ReliabilityCalculator();
            _priorityCalculator = new PriorityCalculator();
            _classificationCalculator = new ClassificationCalculator();
        }

        /// <summary>
        /// Managed the pipeline 
        /// 1. set status to validating.
        /// 2. validate the report.
        /// </summary>
        /// <param name="report"></param>
        public void ProcessReport(Report report)
        {
            report.Status = ReportStatus.Validating;
            ValidateReport(report);
            if(report.Status == ReportStatus.Rejected){return;}
            CalculateMetrics(report);
            StoreReport(report);
        }


        public ReportRepository GetValidatedReports()
        {
            return _validatedReports;
        }


        public RejectedReportRepository GetRejectedReports()
        {
            return _rejectedReports;
        }

        /// <summary>
        /// Display general statistics from reports lists.
        /// </summary>
        public void DisplayStatistics()
        {
            // General counts.
            int countAllReports = _validatedReports.GetTotalCount() + _rejectedReports.GetTotalCount();
            int countValidateReports = _validatedReports.GetTotalCount();
            int countRejectedReports = _rejectedReports.GetTotalCount();
            int successPercentage = 0;
            if(countAllReports != 0)
            {
                successPercentage = countValidateReports * 100 / countAllReports;
            }
            // Priority counts.
            int countLowPriority = _validatedReports.GetByPriority(Priority.Low).Count;
            int countMediumPriority = _validatedReports.GetByPriority(Priority.Medium).Count;
            int countHighPriority = _validatedReports.GetByPriority(Priority.High).Count;
            int countCriticalPriority = _validatedReports.GetByPriority(Priority.Critical).Count;

            // Status counts.
            int countNewStatus = _validatedReports.GetCountByStatus(ReportStatus.New);
            int countValidatingStatus = _validatedReports.GetCountByStatus(ReportStatus.Validating);
            int countValidatedStatus = _validatedReports.GetCountByStatus(ReportStatus.Validated);
            int countInProgressStatus = _validatedReports.GetCountByStatus(ReportStatus.InProgress);
            int countCompletedStatus = _validatedReports.GetCountByStatus(ReportStatus.Completed);

            // Classification count.
            int countUnclassified = _validatedReports.GetCountByClassification(Classification.Unclassified);
            int countRestricted = _validatedReports.GetCountByClassification(Classification.Restricted);
            int countSecret = _validatedReports.GetCountByClassification(Classification.Secret);
            int countTopSecret = _validatedReports.GetCountByClassification(Classification.TopSecret);

            System.Console.WriteLine("=== Statistics ===");
            System.Console.WriteLine("GENERAL");
            System.Console.WriteLine($"AllReports: {countAllReports}| ValidateReports: {countValidateReports}| RejectedReports: {countRejectedReports}| successPercentage: {successPercentage}%");
            System.Console.WriteLine("------------------");
            System.Console.WriteLine("=== Priority counts ===");
            System.Console.WriteLine($"Low: {countLowPriority}| Medium: {countMediumPriority}| High: {countHighPriority}| Critical: {countCriticalPriority}");
            System.Console.WriteLine("------------------");
            System.Console.WriteLine("=== Status counts ===");
            System.Console.WriteLine($"New: {countNewStatus}| Validating: {countValidatingStatus}| Validated: {countValidatedStatus}| InProgress: {countInProgressStatus}| Completed: {countCompletedStatus}");
            System.Console.WriteLine("------------------");
            System.Console.WriteLine("=== Classification count ===");
            System.Console.WriteLine($"Unclassified: {countUnclassified}| Restricted: {countRestricted}| Secret: {countSecret}| TopSecret: {countTopSecret}");

        }


        // Validate and return validation for obj.
        private IValidator? GetValidator(Report report)
        {
            if(report is DroneReport){return new DroneValidator();}
            if(report is RadarReport){return new RadarValidator();}
            if(report is SignalReport){return new SignalValidator();}
            if(report is SoldierReport){return new SoldierValidator();}
            return null;
        }

        /// <summary>
        /// check if obj is valid 
        /// if not, store it in rejection reports
        /// if valid, send the report to calculate.
        /// </summary>
        /// <param name="report"></param>
        private void ValidateReport(Report report)
        {
            
            IValidator validator = GetValidator(report);

            if (validator == null)
            {
                report.Status = ReportStatus.Rejected;
                report.RejectionReason = "Validator not found for this report type.";
                StoreReport(report);
                return;
            }

            ValidationResult checkIfValid = validator.Validate(report);
            if(checkIfValid.IsValid)
            {
                report.Status = ReportStatus.Validated;
                CalculateMetrics(report);
            }
            else
            {
                report.RejectionReason = checkIfValid.ErrorMessage;
                report.Status = ReportStatus.Rejected;
                StoreReport(report);   
            }
        }

        /// <summary>
        /// calculate for Reliability, Priority, Classification.
        /// </summary>
        /// <param name="report"></param>
        private void CalculateMetrics(Report report)
        {
            report.ReliabilityScore = _reliabilityCalculator.Calculate(report);
            report.Priority = _priorityCalculator.Calculate(report);
            report.Classification = _classificationCalculator.Calculate(report);
        }

        /// <summary>
        /// check the status of report,
        /// if rejected send it to rejected reports
        /// if validated send it to validate reports
        /// </summary>
        /// <param name="report"></param>
        private void StoreReport(Report report)
        {
            if(report.Status == ReportStatus.Rejected)
            {
                _rejectedReports.Add(report);
            }
            if(report.Status == ReportStatus.Validated)
            {
                _validatedReports.Add(report);
            }
        }
    }
}