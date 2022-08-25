using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using partieback.Models;
using Microsoft.AnalysisServices.AdomdClient;


namespace partieback.Controllers
{
    public class dimentionController : ApiController
    {
        public HttpResponseMessage post(cubee c)
        {
            string query = @" 
SELECT   [hierarchy_UNIQUE_NAME]
FROM $system.MDSchema_hierarchies 
WHERE CUBE_NAME  ='" + c.cube_name + "' and HIERARCHY_ORIGIN=2  and [dimension_unique_name]<>'[dim calendar]'  ";

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

