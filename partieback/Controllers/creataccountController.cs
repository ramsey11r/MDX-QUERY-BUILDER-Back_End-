using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using partieback.Models;

namespace partieback.Controllers
{
    public class creataccountController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
select iduser,username,userpassword
from dbo.loginn";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["loginappdb"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string post(creataccount crealog)
        {
            try
            {
                string query = @" insert into dbo.loginn values('" + crealog.username + @"','" + crealog.userpassword + @"')";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["loginappdb"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "added successful !!";
            }
            catch (Exception)
            {
                return "failed to add !!";
            }
        }
    }
}