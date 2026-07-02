using System;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Models.Enums;

namespace IntelligencePipeline.Calculators
{
    /// <summary>
    /// Calculate report priority. 
    /// Return obj from Priority enum.
    /// </summary>
    public class PriorityCalculator
    {

        public Priority Calculate(Report report)
        {
            // check if priority is critical. 
            bool hasCriticalDescription = ContainsKeyword(report.Description.ToLower(), "missile", "explosion", "attack", "fire");
            if (hasCriticalDescription){return Priority.Critical;}
            if(report is SignalReport signalCritical)
            {
                if(ContainsKeyword(signalCritical.Content.ToLower(), "missile", "explosion", "attack", "fire")){return Priority.Critical;}
                if(ContainsKeyword(signalCritical.Content.ToLower(), "attack") && ContainsKeyword(signalCritical.Content.ToLower(), "target")){return Priority.Critical;}
            }
            if(report is RadarReport radarCritical && radarCritical.Speed >= 800){return Priority.Critical;}

            // check if priority is high.
            bool hasHighDescription = ContainsKeyword(report.Description.ToLower(),"weapon", "suspicious", "border");
            if (hasHighDescription){return Priority.High;}
            if(report is DroneReport droneHigh && droneHigh.Altitude < 500){return Priority.High;}
            if(report is RadarReport radarHigh && radarHigh.Speed >= 400){return Priority.High;}
            if(report is SoldierReport soldierHigh)
            {
                if(ContainsKeyword(report.Description.ToLower(), "movement") && soldierHigh.ConfidenceLevel >= 4)
                {
                    return Priority.High;
                }
            }

            //  check if priority is medium.
            bool hasMediumDescription = ContainsKeyword(report.Description.ToLower(),"movement", "vehicle", "activity");
            if(hasMediumDescription){return Priority.Medium;}
            if(report is RadarReport radarMedium && radarMedium.Speed >= 120){return Priority.Medium;}
            if(report.ReliabilityScore >= 7){return Priority.Medium;}
            
            return Priority.Low;
        }

        /// <summary>
        /// Check if word/words exist in text.
        /// </summary>
        /// <param name="text">the text</param>
        /// <param name="keywords">the keywords</param>
        /// <returns>boolean if word exist or not</returns>
        private bool ContainsKeyword(string text, params string[] keywords)
        {
            foreach (string key in keywords)
            {
                if(text.Contains(key)){return true;}
            }
            return false;
        }
    
}
}