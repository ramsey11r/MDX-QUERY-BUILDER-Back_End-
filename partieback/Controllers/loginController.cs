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
    public class loginController : ApiController
    {
      

   

        public Boolean post(login log)
        {
            
                string query = @"select * from dbo.loginn where username='" +log.username+ "' and userpassword= '" + log.userpassword + "'";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["loginappdb"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);

                }

                if (table.Rows.Count > 0)
                {
                return true;

                }
                else
                {
                    return false;
                }
                
            }


        }


    }
