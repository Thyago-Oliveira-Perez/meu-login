using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using API_meu_login.Service;
using API_meu_login.Model;
using System.Data;
using Newtonsoft.Json;

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

        [HttpPost("login")]
        public object GetAcess([FromBody]object json)
        {

            if (json != null)
            {
                ServiceUser user = new ServiceUser();

                if (user.GetUserByEmail(json.ToString()) != null)
                {
                    return Ok();
                    //return JsonConvert.SerializeObject(user.GetUserByEmail(json.ToString()));             
                }
            }
            return NotFound();
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