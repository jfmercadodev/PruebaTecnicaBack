using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ComicRepository(ApplicationDbContext context) : IComicRepository
    {
        public async Task AddComicToUserAsync(int userId, int comicId)
        {
            var userComic = new UserComic
            {
                UserId = userId,
                ComicId = comicId
            };

            context.UserComics.Add(userComic);
            await context.SaveChangesAsync();
        }

        public Task<List<UserComic>> GetListComicByUserId(int userId)
        {
            return context.UserComics.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task RemoveComicFromUserAsync(int userId, int comicId)
        {
            var userComic = await context.UserComics.FindAsync(userId, comicId);
            if (userComic != null)
            {
                context.UserComics.Remove(userComic);
                await context.SaveChangesAsync();
            }
        }

    }
}

