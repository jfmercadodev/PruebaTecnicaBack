using Application.DTOs;
using Application.Interfaces.External;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class ComicService(IComicRepository comicRepository, IMarvelApiService marvelApiService)
        : IComicService
    {
        public async Task<bool> AddFavoriteComicAsync(int userId, int comicId)
        {
            try
            {
                await comicRepository.AddComicToUserAsync(userId, comicId);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error añadiendo cómic a favoritos: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> RemoveFavoriteComicAsync(int userId, int comicId)
        {
            try
            {
                await comicRepository.RemoveComicFromUserAsync(userId, comicId);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error eliminando cómic de favoritos: {ex.Message}");
                return false;
            }
        }
        public async Task<List<MarvelComicDto>> GetUserFavoriteComicsAsync(int userId)
        {
            try
            {
                var comicsFavList = await comicRepository.GetListComicByUserId(userId);
                var comics = await marvelApiService.GetComicsAsync();

                var favoriteComicIds = comicsFavList.Select(cf => cf.ComicId).ToHashSet();

                var availableComics = comics
                    .Where(c => favoriteComicIds.Contains(c.Id))
                    .ToList();

                return availableComics;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error filtrando cómics: {ex.Message}");
                return new List<MarvelComicDto>();
            }

        }
    }
}
