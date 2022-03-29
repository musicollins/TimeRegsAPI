using TimeRegApi.Model;
using System.Collections.Generic;

namespace TimeRegApi.UI.DataAccessUI
{
    public interface ITimeReportsDataAccess
    {
        //TIME REPORT
        IEnumerable<TimeReport> GetTimeReports();
        TimeReport GetTById(int timeReportid);
        void AddT(TimeReport timeReport);
        void SaveTAsync(TimeReport timeReport);
        void DeleteTAsync(int timeReportid);
    }
}