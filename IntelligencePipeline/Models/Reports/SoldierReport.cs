using System;

namespace IntelligencePipeline.Models.Reports
{
    public class SoldierReport : Report
    {
        public string SoldierName { get; protected set; }
        public string SoldierID { get; }
        public string Unit { get; protected set; }
        public int ConfidenceLevel { get; protected set; }

        public SoldierReport(DateTime timestamp, double latitude,double longitude, 
                            string description, string soldierName, string soldierID,
                            string unit, int confidenceLevel)
                : base(timestamp, latitude, longitude, description)
        {
            SoldierName = soldierName;
            SoldierID = soldierID;
            Unit = unit;
            ConfidenceLevel = confidenceLevel;
        }

        public override string GetSourceType()
            => "Soldier";

        public override string GetSummary()
        {
            return $"ID: {ReportId}| DATE: {Timestamp}| LATITUDE: {Latitude}|  DESCRIPTION: {Description}| STATUS: {Status}";
        }

        public override int CalculateReliabilityScore()
        {
            int score = 4;
            string lowerDesc = Description.ToLower();
            if(lowerDesc.Contains("weapon") || lowerDesc.Contains("vehicle")
                || lowerDesc.Contains("movement") || lowerDesc.Contains("explosion"))
            {
                score += 1;
            }
            
            score += ConfidenceLevel;
            return score;
        }
    }

    
}