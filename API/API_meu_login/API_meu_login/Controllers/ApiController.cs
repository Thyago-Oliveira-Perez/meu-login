using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace API_meu_login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        public ApiController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        [HttpGet("login")]
        public string Get()
        {
            string texto = " Web API - ImagemController em execução : " + DateTime.Now.ToLongTimeString();
            texto += $"\n Ambiente :  {_environment.EnvironmentName}";
            return texto;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> Post(IFormFile json)
        {
            if (json != null)
            {
                return Ok(json.FileName);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}