using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using partieback.Models;

using Microsoft.AnalysisServices.AdomdClient;

namespace partieback.Controllers
{
    public class cubeController : ApiController
    {
        public HttpResponseMessage get()
        {
            string query = @"SELECT cube_name

FROM $system.MDSchema_Cubes WHERE CUBE_SOURCE=1";

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