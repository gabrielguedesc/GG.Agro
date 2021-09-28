using GG.Agro.Application.DTOs;
using GG.Agro.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GG.Agro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeywordController : ControllerBase
    {
        [HttpGet]
        public IActionResult Replace([FromServices] IKeywordReplaceService keywordReplaceService)
        {
            var contract = new ContractDTO()
            {
                Name = "Gabriel Guedes Correa"
            };

            var file = @"Contracto ##INSUMO##";

            var result = keywordReplaceService.Replace(file, contract);

            return Ok(result);
        }
    }
}
