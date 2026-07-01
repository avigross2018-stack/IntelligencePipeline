using System;
using IntelligencePipeline.Models.Enums;

namespace IntelligencePipeline.Models.Reports
{
    public class SignalReport : Report
    {
        public double Frequency { get; protected set; }
        public string Content { get; protected set; }
        public Language Language { get; protected set; }
        public int SignalStrength { get; protected set; }

        public SignalReport(DateTime timestamp, double latitude,double longitude, 
                            string description, double frequency, string content,
                            Language language, int signalStrength)
                : base(timestamp, latitude, longitude, description)
        {
            Frequency = frequency;
            Content = content;
            Language = language;
            SignalStrength = signalStrength;
        }

        public override string GetSourceType()
            => "Signal";

        public override int CalculateReliabilityScore()
        {
            int score = 5;
            string lowerContent = Description.ToLower();
            if(SignalStrength >= -40){score += 3;}
            else if(SignalStrength >= -70){score += 2;}
            else if(SignalStrength < -100){score -= 2;}

            if(lowerContent.Contains("attack") || lowerContent.Contains("target")
                || lowerContent.Contains("border") || lowerContent.Contains("vehicle"))
            {
                score += 1;
            }

            return score;
        }     
    }

}