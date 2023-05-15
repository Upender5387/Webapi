using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    public class ValuesController : ApiController
    {
        string con = System.Configuration.ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString;
        public object Get()
        {
            List<value> persons = new List<value>();
            DataTable objresutl = new DataTable();
            try
            {
                SqlDataReader myReader;
                string query = "select * from Persons";
                using (SqlConnection myCon = new SqlConnection(con))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        if (myReader.HasRows)
                        {
                           
                            while (myReader.Read())
                                {
                                    value value1 = new value();
                                    value1.PersonID = myReader["PersonID"].ToString();
                                    value1.LastName = myReader["LastName"].ToString();
                                    value1.FirstName = myReader["FirstName"].ToString();
                                    value1.Address = myReader["Address"].ToString();
                                    value1.City = myReader["City"].ToString();
                                    persons.Add(value1);
                            }
                            objresutl.Load(myReader);
                            myReader.Close();
                            myCon.Close();

                        }
                    }
                }
            }
            catch (Exception)
            {
            }
         return Ok(persons);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
