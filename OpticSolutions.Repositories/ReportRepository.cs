using OpticSolutions.Repositories.Entitys;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpticSolutions.ViewModels;
using Dapper;

namespace OpticSolutions.Repositories
{
    public class ReportRepository
    {
        public SqlConnection conn = new SqlConnection();

        public ReportRepository()
        {
            conn.ConnectionString = "Server=tcp:opticsolutions.database.windows.net,1433;Initial Catalog=OpticSolutions;Persist Security Info=False;User ID=osuser;Password=p@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        public List<ReportObject> GetReportData(ReportViewModel rep)
        {
            conn.Open();
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@type", rep.TypeOfReport);
            queryParameters.Add("@time_skip", rep.TimeSkip);
            queryParameters.Add("@start_date",rep.StartDate);
            queryParameters.Add("@end_date", rep.EndDate);
      

            var data = conn.Query<ReportObject>("GET_REPORT_DATA", queryParameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
            conn.Close();
            return data;
        }

        

    }
}
