using Application.Interfaces.External;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnicaBack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MarvelController : ControllerBase
    {
        private readonly IMarvelApiService _marvelService;

        public MarvelController(IMarvelApiService marvelService)
        {
            _marvelService = marvelService;
        }

        [HttpGet("comics")]
        public async Task<IActionResult> GetComics()
        {
            var result = await _marvelService.GetComicsAsync();
            return Ok(result);
        }
    }
}
