using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioEncuestas.Controllers
{
    public class EjController : ApiController
    {
        // GET: api/Ej
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Ej/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Ej
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Ej/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Ej/5
        public void Delete(int id)
        {
        }
    }
}
