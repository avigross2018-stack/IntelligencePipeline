using System;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Pipeline;
using IntelligencePipeline.Storage;
using IntelligencePipeline.Validation;

namespace IntelligencePipeline.Menu
{
    public class NewReport
    {
        private ValidateInput _validateInput;
        private ReportPipeline _pipeline;
        public NewReport(ReportPipeline reportPipeline)
        {
            _validateInput = new ValidateInput();
            _pipeline = reportPipeline;
        }

        public void NewDroneReport()
        {           
            System.Console.WriteLine("Enter DateTime in format (yy-mm-dd hh:mm)");
            DateTime date = _validateInput.ValidDate();
            System.Console.WriteLine("Enter Latitude");

            double latitude = _validateInput.ValidDouble();
            System.Console.WriteLine("Enter Longitude");

            double longitude = _validateInput.ValidDouble();
            System.Console.WriteLine("Enter Description");
            string description = Console.ReadLine();

            System.Console.WriteLine("Enter Altitude");
            int altitude = _validateInput.ValidInt();

            System.Console.WriteLine("Enter ImageQuality");
            int imageQuality = _validateInput.ValidInt();

            DroneReport newDrone= new(date, latitude, longitude, description, altitude, imageQuality);
            _pipeline.ProcessReport(newDrone);
        }

        public void NewRadarReport()
        {
            System.Console.WriteLine("Enter DateTime in format (yy-mm-dd hh:mm:ss)");
            DateTime date = _validateInput.ValidDate();

            System.Console.WriteLine("Enter Latitude");
            double latitude = _validateInput.ValidDouble();

            System.Console.WriteLine("Enter Longitude");
            double longitude = _validateInput.ValidDouble();

            System.Console.WriteLine("Enter Description");
            string description = Console.ReadLine();

            System.Console.WriteLine("Enter Speed");
            int speed = _validateInput.ValidInt();

            System.Console.WriteLine("Enter Direction");
            int direction = _validateInput.ValidInt();

            System.Console.WriteLine("Enter Distance");
            int distance = _validateInput.ValidInt();

            RadarReport newRadar = new(date, latitude, longitude, description, speed, direction, distance);
            _pipeline.ProcessReport(newRadar);        
        }

        public void NewSignalReport()
        {
            System.Console.WriteLine("Enter DateTime in format (yy-mm-dd hh:mm:ss)");
            DateTime date = _validateInput.ValidDate();

            System.Console.WriteLine("Enter Latitude");
            double latitude = _validateInput.ValidDouble();

            System.Console.WriteLine("Enter Longitude");
            double longitude = _validateInput.ValidDouble();

            System.Console.WriteLine("Enter Description");
            string description = Console.ReadLine();

            System.Console.WriteLine("Enter Frequency");
            double frequency = _validateInput.ValidInt();

            System.Console.WriteLine("Enter Content");
            string content = Console.ReadLine();

            System.Console.WriteLine("Enter Language");
            Language language = _validateInput.ValidLanguageEnum();

            System.Console.WriteLine("Enter SignalStrength");
            int signalStrength = _validateInput.ValidInt();

            SignalReport newSignal = new(date, latitude, longitude, description, frequency, content, language, signalStrength);
            _pipeline.ProcessReport(newSignal);        
        }

        public void NewSoldierReport()
        {
            System.Console.WriteLine("Enter DateTime in format (yy-mm-dd hh:mm:ss)");
            DateTime date = _validateInput.ValidDate();

            System.Console.WriteLine("Enter Latitude");
            double latitude = _validateInput.ValidDouble();

            System.Console.WriteLine("Enter Longitude");
            double longitude = _validateInput.ValidDouble();

            System.Console.WriteLine("Enter Description");
            string description = Console.ReadLine();

            System.Console.WriteLine("Enter SoldierName");
            string soldierName = Console.ReadLine();

            System.Console.WriteLine("Enter SoldierID");
            string soldierID = Console.ReadLine();

            System.Console.WriteLine("Enter Unit");
            string unit = Console.ReadLine();

            System.Console.WriteLine("Enter ConfidenceLevel");
            int confidenceLevel = _validateInput.ValidInt();

            SoldierReport newSoldier = new(date, latitude, longitude, description, soldierName, soldierID, unit, confidenceLevel);
            _pipeline.ProcessReport(newSoldier);        
        }       
    }
}