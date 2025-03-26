using Aiko.Dto;
using Aiko.Repository.Services.Interface;
using Aiko_teste.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aiko_teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtratoController : ControllerBase
    {
        private readonly IExtratoService _extratoService;
        private readonly IUtil _util;

        public ExtratoController(IExtratoService extratoService, IUtil util)
        {
            _extratoService = extratoService;
            _util = util;
        }

        [HttpPost]
        public async Task<IActionResult> GerarExtrato([FromBody] ExtratoRequest model)
        {
            try
            {
                var response = await _extratoService.GerarExtrato(model);

                if (response.IsFailed)
                {
                    return BadRequest(response);
                }

                await _util.CriarArquivo(response.Successes.FirstOrDefault().Message,"Extrato", model.FormatoArquivo);

                return Ok(response.Successes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
