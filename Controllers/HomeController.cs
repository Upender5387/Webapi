using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using WebAPIDemo.DataAccesssLayer;
using WebAPIDemo.Models;


namespace WebAPIDemo.Controllers
{

    [EnableCors("*")] // tune to your needs
    [RoutePrefix("")]
    public class HomeController : ApiController
    {
        string con = System.Configuration.ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString;
       
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = Homedata.Get1();
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult insert(newProduct1 obj)
        {
            var data = Homedata.InsertProduct( obj);
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Update(newProduct obj)
        {
            var data = Homedata.UpdateProduct(obj);
            return Ok(data);
        }


        
       
    }
}
   


