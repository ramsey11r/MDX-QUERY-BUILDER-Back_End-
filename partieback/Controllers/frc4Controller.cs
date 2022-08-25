using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using partieback.Models;
using Microsoft.AnalysisServices.AdomdClient;
namespace partieback.Controllers
{
    public class frc4Controller : ApiController
    {

        public HttpResponseMessage Post(frc a)
        {
            string query = @"select  non empty{
                (" + a.selectdimentioncolumns + ".members," + a.selectmeasurecolumns + ")} on columns,non empty (" + a.selectdimentionrows + ".members) on rows from [BI]";
            DataTable table = new DataTable();
            using (var conn = new AdomdConnection(@"Data Source=LAPTOP-51AOCNRN\SQL2019"))
            using (var cmd = new AdomdCommand(query, conn))
            using (var da = new AdomdDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }



            return Request.CreateResponse(HttpStatusCode.OK, table);
            }

        }
    }
