using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IComicService
    {
        Task<bool> AddFavoriteComicAsync(int userId, int comicId);
        Task<bool> RemoveFavoriteComicAsync(int userId, int comicId);
        Task<List<MarvelComicDto>> GetUserFavoriteComicsAsync(int userId);
    }
}
