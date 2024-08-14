using Lista3.Api.Enums;
using Lista3.Api.Request;
using Microsoft.AspNetCore.Mvc;

namespace Lista3.Api.Controllers
{
    [Route("api/[controller]")]
    public class FreteController : Controller
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CalcularFrete([FromBody] CalculaFreteRequest request)
        {
            if (request.UF.Length !=  2)
            {
                return BadRequest("UF só pode conter 2 dígitos");
            }

            int taxa = 0;

            if (request.UF == "SP")
            {
                taxa = (int)TarifasFrete.SP;
            }
            else if (request.UF == "RJ")
            {
                taxa = (int)TarifasFrete.RJ;
            }
            else if (request.UF == "MG")
            {
                taxa = (int)TarifasFrete.MG;
            }   
            else
            {
                taxa = (int)TarifasFrete.Outros;
            }
            double volume = request.AlturaProduto * request.LarguraProduto * request.ComprimentoProduto;
            double frete = volume * 0.001 + taxa;
            return Ok(frete);
        }
    }
}
