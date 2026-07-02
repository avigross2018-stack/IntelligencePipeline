using System;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Models.Enums;

namespace IntelligencePipeline.Storage
{
    public class RejectedReportRepository
    {
        private List<Report> _rejectedReports;

        public RejectedReportRepository()
        {
            _rejectedReports = new List<Report>();
        }


        public void Add(Report report)
        {
            _rejectedReports.Add(report);
        }
        public List<Report> GetAll()
        {
            return _rejectedReports;
        }


        public int GetTotalCount()
        {
            return _rejectedReports.Count;
        }


        public List<Report> GetByReason(string reasonKeyword)
        {
            List<Report> searchByKeyword = new List<Report>();

            foreach (var report in _rejectedReports)
            {
                if(report.Description.Contains(reasonKeyword))
                {
                    searchByKeyword.Add(report);
                }
            }
            return searchByKeyword;
        }        
    }
}