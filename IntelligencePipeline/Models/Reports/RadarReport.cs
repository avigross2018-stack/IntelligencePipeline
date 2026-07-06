using System;

namespace IntelligencePipeline.Models.Reports
{
    public class RadarReport : Report
    {
        public int Speed { get; protected set; }
        public int Direction { get; protected set; }
        public int Distance { get; protected set; }


        public RadarReport(DateTime timestamp, double latitude,double longitude, 
                            string description, int speed, int direction, int distance)
                : base(timestamp, latitude, longitude, description)
        {
            Speed = speed;
            Direction = direction;
            Distance = distance;
        }

        public override string GetSourceType()
            => "Radar";

        public override int CalculateReliabilityScore()
        {
            int score = 6;
            if(Distance >= 500 && Distance <= 30000){score += 2;}
            else if(Distance > 70000){score -= 2;}
            
            if(Speed >= 10 && Speed <= 900){score += 1;}
            else if(Speed > 1500){score -= 2;}

            return score;
        } 

        public override string GetSummary()
        {
            return $"""
            ID: {ReportId}
            TYPE: RADAR
            DATE: {Timestamp}
            LATITUDE: {Latitude}
            DESCRIPTION: {Description}
            STATUS: {Status}
            PRIORITY: {Priority}
            CLASSIFICATION: {Classification}
            SPEED: {Speed}
            DIRECTION: {Direction}
            DISTANCE: {Distance}
            REJECTION: {RejectionReason}
            """;
        }      
    }
}