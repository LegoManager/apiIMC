using Lista3.Api.Request;
using Microsoft.AspNetCore.Mvc;

namespace Lista3.Api.Controllers
{
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        [HttpPost()]
        [Route("/api/calcula-imc")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CalculaIMC ([FromBody]CalculaImcRequest request)
        {
            double alturaEmMetros = request.Altura / 100.0;
            double IMC = request.Peso / Math.Pow(alturaEmMetros, 2);
            return Ok(Math.Round(IMC, 2));
        }
        [HttpGet]
        [Route(("/api/consulta-tabela-imc/{IMC}"))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ConsultaTabelaIMC([FromRoute] double IMC)
        {
            if (IMC < 18.5)
            {
                return Ok("Abaixo do Peso Normal");
            }
            else if (IMC >= 18.5 || IMC < 25)
            {
                return Ok("Peso normal");
            }
            else if (IMC >= 25 ||IMC <35)
            {
                return Ok("Excesso de peso");
            }
            else if (IMC >= 30 ||IMC < 35)
            {
                return Ok("Obsesidade classe 1");
            }
            else if (IMC >= 35 || IMC < 40)
            {
                return Ok("Obsesidade classe 2");
            }
            else
            {
                return Ok("Obsesidade classe 3");
            }
        }
    }
}
