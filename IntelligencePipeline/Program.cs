using System;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Pipeline;
using IntelligencePipeline.Storage;
using IntelligencePipeline.Validation;
using IntelligencePipeline.Menu;
using IntelligencePipeline.Models.Enums;

namespace IntelligencePipeline
{
    class Program
    {

        public static void Main(string[] args)
        {
            ReportPipeline reportPipeline = new();
            // RejectedReportRepository rejectedReportRepository = new();
            ReportRepository reportRepository = new();
            ValidateInput  validateInput = new();
            NewReport newReport = new(reportPipeline);

            bool Menuflag = true;
            while (Menuflag)
            {
                System.Console.WriteLine("== Report intelligence ==");
                System.Console.WriteLine("""
                                            1. Add New Report
                                            2. View All Validated Reports
                                            3. View Rejected Reports
                                            4. View Single Report Details (by ID)
                                            5. Search in Reports By Keyword
                                            6. Filter Reports By Status
                                            7. Filter Reports By Priority
                                            8. Sort Reports
                                            9. Update Report Status
                                            10. Show System Statistics
                                            0. Exit
                                            """);
                string mainMenu = Console.ReadLine();
                switch (mainMenu)
                {
                    case "1":
                        NewReport(newReport);
                        continue;

                    case "2":
                        List<Report> validReports = reportPipeline.GetValidatedReports().GetAll();
                        foreach(Report report in validReports)
                        {
                            System.Console.WriteLine(report.GetSummary());
                            System.Console.WriteLine("-------");
                        }
                        continue;
                    case "3":
                        List<Report> rejectedReports = reportPipeline.GetRejectedReports().GetAll();
                        foreach(Report report in rejectedReports)
                        {
                            System.Console.WriteLine(report.GetSummary());
                            System.Console.WriteLine("-------");
                        }
                        continue;
                    case "4":
                        System.Console.WriteLine("Enter ID");
                        int searchId = validateInput.ValidInt();
                        Report? searchReport = reportRepository.GetById(searchId);
                        if(searchReport is not null){System.Console.WriteLine(searchReport.GetSummary());}
                        else{System.Console.WriteLine("ID Not found");}
                        continue;
                    case "5":
                        System.Console.WriteLine("Enter keyword");
                        string keyword = Console.ReadLine();
                        List<Report> searchByKeyword = reportRepository.Search(keyword);
                        foreach(Report report in searchByKeyword)
                        {
                            System.Console.WriteLine(report.GetSummary());
                            System.Console.WriteLine("-------");
                        }
                        continue;
                    case "6":
                        System.Console.WriteLine("Enter status (New, Validating, Validated, Rejected, InProgress, Completed)");
                        if(Enum.TryParse<ReportStatus>(Console.ReadLine(), true, out ReportStatus statusResult))
                        {
                            List<Report> searchByStatus = reportRepository.GetByStatus(statusResult);
                            foreach(Report report in searchByStatus)
                            {
                            System.Console.WriteLine(report.GetSummary());
                            System.Console.WriteLine("-------");
                            }
                        }
                        else{System.Console.WriteLine("Invalid Status");}
                        continue;
                    case "7":
                        System.Console.WriteLine("Enter Priority (Low, Medium, High, Critical)");
                        if(Enum.TryParse<Priority>(Console.ReadLine(), true, out Priority PriorityResult))
                        {
                            List<Report> searchByPriority = reportRepository.GetByPriority(PriorityResult);
                            foreach(Report report in searchByPriority)
                            {
                            System.Console.WriteLine(report.GetSummary());
                            System.Console.WriteLine("-------");
                            }
                        }
                        else{System.Console.WriteLine("Invalid Priority");}
                        continue;
                    case "9":
                        System.Console.WriteLine("Enter ID");
                        int updateId = validateInput.ValidInt();
                        Report? UpdateReport = reportRepository.GetById(updateId);
                        if(UpdateReport is not null)
                        {
                            System.Console.WriteLine("Enter status (New, Validating, Validated, Rejected, InProgress, Completed)");
                            if(Enum.TryParse<ReportStatus>(Console.ReadLine(), true, out ReportStatus updateStatus))
                            {
                                UpdateReport.Status = updateStatus;
                            }
                            System.Console.WriteLine("Invalid Status");
                        }
                        else{System.Console.WriteLine("ID Not found");}
                        continue;
                    case "10":
                        reportPipeline.DisplayStatistics();
                        continue;
                    case "0":
                    Menuflag = false;
                        break;
                    default:
                        System.Console.WriteLine("Invalid input (0-9)");
                        continue;
                }
            }

        }

        public static void NewReport(NewReport newReport)
        {
            
                System.Console.WriteLine("== Source Report ==");
                System.Console.WriteLine("""
                                        1. Drone.
                                        2. Radar.
                                        3. Signal.
                                        4. Soldier.
                                        """);
                string newMenu = Console.ReadLine();
                switch (newMenu)
                {
                    case "1":
                        newReport.NewDroneReport();
                        break;
                    case "2":
                        newReport.NewRadarReport();
                        break;
                    case "3":
                        newReport.NewSignalReport();
                        break;
                    case "4":
                        newReport.NewSoldierReport();
                        break;
                    default:
                        System.Console.WriteLine("Invalid input (1-4)");
                        break;
                }
            
        }
    }
}
