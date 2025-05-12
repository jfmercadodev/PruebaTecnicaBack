using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IComicRepository
    {
        Task AddComicToUserAsync(int userId, int comicId);
        Task RemoveComicFromUserAsync(int userId, int comicId);
        Task<List<UserComic>> GetListComicByUserId(int  userId);
    }
}

