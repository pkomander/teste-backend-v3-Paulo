using Aiko.Dto;
using Aiko.Repository.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aiko_teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayController : ControllerBase
    {

        private readonly IPlayService _playService;

        public PlayController(IPlayService playService)
        {
            _playService = playService;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionaCargo([FromBody] PlayDto model)
        {
            try
            {
                var response = await _playService.Adicionar(model);

                if (response.IsFailed)
                {
                    return BadRequest(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _playService.GetAll();

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
