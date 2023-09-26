using API_TESTE.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TESTE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomaController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get(string numero)
        {
            int num = Convert.ToInt32(numero);

            return Ok(num + 1);
        }

        [HttpPost]
        public ActionResult Post([FromBody]PostNumero numero) 
        {
            int num = Convert.ToInt32(numero.numero);

            numero.nome = "Marco Marques";
            numero.idade++;
            numero.numero = (num + 1).ToString();

            return Ok(numero);    
        }
    }
}
