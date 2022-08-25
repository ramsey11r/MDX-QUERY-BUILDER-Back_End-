﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace partieback.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get()
        { 
           var retVal =new { key1="value1" ,key2="value2"};  

        
            return Request.CreateResponse(HttpStatusCode.OK,retVal);
        }
     

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public  HttpResponseMessage Post([FromBody] string value)
        {
            var retVal = new { key1 = "value1", key2 = "value2" };

            return Request.CreateResponse(HttpStatusCode.OK, retVal);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
       
    }
}
