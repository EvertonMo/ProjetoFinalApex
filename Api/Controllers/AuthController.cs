using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "feito get";
        }

        [HttpPost]
        public string Post()
        {
            return "feito Post";
        }

        [HttpPut]
        public string Put()
        {
            return "feito Put";
        }

        [HttpDelete]
        public string Delete()
        {
            return "deletado";
        }
    }
}
