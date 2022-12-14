using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using partieback.Models;
using Microsoft.AnalysisServices.AdomdClient;
namespace partieback.Controllers
{
    public class frc6Controller : ApiController
    {


        public HttpResponseMessage Post(frc a)
        {

            string query = @"select non  empty(" + a.selectdimentioncolumns + ".members) on columns, non empty(" + a.selectdimentionrows + ".members)on rows from [BI]";

            DataTable table = new DataTable();
            using (var conn = new AdomdConnection(@"Data Source=LAPTOP-51AOCNRN\SQL2019"))
            using (var cmd = new AdomdCommand(query, conn))
            using (var da = new AdomdDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            foreach (DataColumn d in table.Columns)
            {

                int start = d.ColumnName.LastIndexOf("[");
                d.ColumnName = d.ColumnName.Substring(start + 1).Replace("]", ""); //ColumnNameReplace;
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

    }
}