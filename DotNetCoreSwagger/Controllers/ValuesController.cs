﻿using System;
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
        [ApiExplorerSettings(GroupName = "docV1")]//Groupname必须与文档名一致且区分大小写
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
        [ApiExplorerSettings(GroupName = "docV2")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// post方法
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        [ApiExplorerSettings(GroupName = "docV1")]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ApiExplorerSettings(GroupName = "docV1")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ApiExplorerSettings(GroupName = "docV1")]
        public void Delete(int id)
        {
        }
    }
}
