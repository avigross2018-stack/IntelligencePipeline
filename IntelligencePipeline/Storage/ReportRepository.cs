using System;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Models.Enums;

namespace IntelligencePipeline.Storage
{
    public class ReportRepository
    {
        private List<Report> _reports;

        public ReportRepository()
        {
            _reports = new List<Report>();
        }


        public void Add(Report report)
        {
            _reports.Add(report);
        }


        public List<Report> GetAll()
        {
            return _reports;
        }


        public List<Report> GetByStatus(ReportStatus status)
        {
            List<Report> reportsByStatus = new List<Report>();

            foreach (var report in _reports)
            {
                if(report.Status == status)
                {
                    reportsByStatus.Add(report);
                }
            }
            return reportsByStatus;
        }


        public List<Report> GetByPriority(Priority priority)
        {
            List<Report> reportsByPriority = new List<Report>();

            foreach (var report in _reports)
            {
                if(report.Priority == priority)
                {
                    reportsByPriority.Add(report);
                }
            }
            return reportsByPriority;
            
        }


        public List<Report> Search(string keyword)
        {
            List<Report> searchByKeyword = new List<Report>();

            foreach (var report in _reports)
            {
                if(report.Description.Contains(keyword))
                {
                    searchByKeyword.Add(report);
                }
            }
            return searchByKeyword;
            
        }


        public Report? GetById(int reportId)
        {
            foreach (var report in _reports)
            {
                if(report.ReportId == reportId)
                {
                    return report;
                }
            }
            return null;
            
        }


        public void UpdateStatus(int reportId, ReportStatus newStatus)
        {
            foreach (var report in _reports)
            {
                if(report.ReportId == reportId)
                {
                    report.Status = newStatus;
                }
            }
        }


        public int GetTotalCount()
        {
            return _reports.Count;
        }

        
        public int GetCountByStatus(ReportStatus status)
        {
            List<Report> reportsByStatus = new List<Report>();

            foreach (var report in _reports)
            {
                if(report.Status == status)
                {
                    reportsByStatus.Add(report);
                }
            }
            return reportsByStatus.Count;
        }       
    }
}