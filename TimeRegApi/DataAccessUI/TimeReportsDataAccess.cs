using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TimeRegApi.Data;
using TimeRegApi.Model;

namespace TimeRegApi.UI.DataAccessUI
{
    public class TimeReportsDataAccess : ITimeReportsDataAccess
    {
        private readonly TRDbContext _tRDbContext;

        public TimeReportsDataAccess(TRDbContext tRDbContext)
        {
            _tRDbContext = tRDbContext;
        }

        //TIMEREPORT    
        public IEnumerable<TimeReport> GetTimeReports()
        {
            return _tRDbContext.TimeReports.ToList();
        }

        public TimeReport GetTById(int timeReportid)
        {
            return _tRDbContext.TimeReports.AsNoTracking().Single(e => e.TimeReportId == timeReportid);
        }

        public void SaveTAsync(TimeReport timeReport)
        {
            //Retrieve the object first, then update it!
            var b = _tRDbContext.TimeReports.SingleOrDefault(p => p.TimeReportId == timeReport.TimeReportId);
            //CloneIt Method exists in the book model for the purposes of updating object
            //before it is saved into the database
            b.CloneIt(timeReport);

            //_tDbContext.Entry(book).State = EntityState.Modified;
            _tRDbContext.SaveChanges();
        }

        public void DeleteTAsync(int timeReportid)
        {
            var b = _tRDbContext.TimeReports.SingleOrDefault(p => p.TimeReportId == timeReportid);

            _tRDbContext.TimeReports.Remove(b);
            _tRDbContext.SaveChanges();
        }

        public void AddT(TimeReport timeReport)
        {
            _tRDbContext.TimeReports.Add(timeReport);

            var b = _tRDbContext.TimeReports.SingleOrDefault(p => p.TimeReportId == timeReport.TimeReportId);

            _tRDbContext.SaveChanges();
        }
    }
}
