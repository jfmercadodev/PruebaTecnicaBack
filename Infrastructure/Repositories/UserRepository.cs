using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.User.FindAsync(id);
        }
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            IEnumerable<User> users = await GetAllUsersAsync();
            return users.FirstOrDefault(u => u.Email == email) ;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.User.Where(x=>x.Status).ToListAsync();
        }
        public async Task AddUserAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUserAsync(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUserAsync(int id)
        {
            var user = await GetUserByIdAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> UserExistsAsync(string email)
        {
            return await _context.User.AnyAsync(u => u.Email == email);
        }
    }
}
