using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreSwagger.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        /// <summary>
        /// Get method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// get one 
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// post方法
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
