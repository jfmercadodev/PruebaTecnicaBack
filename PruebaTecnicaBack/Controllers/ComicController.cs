using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ComicController(IComicService comicService) : ControllerBase
    {
        [HttpPost("{userId}/favorite/{comicId}")]
        public async Task<IActionResult> AddFavoriteComic(int userId, int comicId)
        {
            var result = await comicService.AddFavoriteComicAsync(userId, comicId);
            if (result)
                return Ok(new { message = "Comic añadido a favoritos correctamente" });

            return BadRequest(new { message = "No se pudo añadir el comic a favoritos" });
        }

        [HttpDelete("{userId}/favorite/{comicId}")]
        public async Task<IActionResult> RemoveFavoriteComic(int userId, int comicId)
        {
            var result = await comicService.RemoveFavoriteComicAsync(userId, comicId);
            if (result)
                return Ok(new { message = "Comic eliminado de favoritos correctamente" });

            return BadRequest(new { message = "No se pudo eliminar el comic de favoritos" });
        }

        [HttpGet("{userId}/favorites")]
        public async Task<IActionResult> GetUserFavoriteComics(int userId)
        {
            var comics = await comicService.GetUserFavoriteComicsAsync(userId);
            return Ok(comics);
        }
    }
}