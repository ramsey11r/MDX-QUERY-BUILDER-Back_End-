using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using partieback.Models;
using Microsoft.AnalysisServices.AdomdClient;
namespace partieback.Controllers
{
    public class measureController : ApiController
    {
        public HttpResponseMessage post(cubee c )
        {
            string query = @"SELECT measure_unique_name
FROM $SYSTEM.MDSCHEMA_MEASURES 
WHERE CUBE_NAME  ='" + c.cube_name + "'";

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

