using System;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Calculators
{
    public class ReliabilityCalculator
    {
        public int Calculate(Report report)
        {
           return report.CalculateReliabilityScore();
        }
    }
}