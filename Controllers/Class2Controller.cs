using System.Web.Http;
using System.Web.Http.Cors;
using WebAPIDemo.DataAccesssLayer;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    [EnableCors("*", "*", "*", "*")] // tune to your needs

    [RoutePrefix("")]
    public class Class2Controller : ApiController
    {
        string con = System.Configuration.ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString;

        [HttpGet]
        public IHttpActionResult Get2()
        {
            var data = Class21.Get2();
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Login(string username, string password)
        {
            var data = Class21.Login(username, password);
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult insert1(Product1 obj)
        {
            var data = Class21.InsertProduct1(obj);
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Update1(Product obj)
        {
            var data = Class21.UpdateProduct1(obj);
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Delete(Product12 obj)
        {
            var data = Class21.DeleteProduct1(obj);
            return Ok(data);
        }
    }
}