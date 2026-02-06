using DbViewChallenge.Api.Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DbViewChallenge.Api.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatorioPesoController : ControllerBase
    {
        private readonly IRelatorioPesoService _service;

        public RelatorioPesoController(IRelatorioPesoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dados = await _service.GetRelatorioPesoViewAsync();
            return Ok(dados);
        }
    }
}
