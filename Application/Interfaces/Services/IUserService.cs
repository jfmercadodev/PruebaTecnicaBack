using Application.DTOs;


namespace Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserCreateUpdateDto?> GetUserByIdAsync(int id);
        Task<UserCreateUpdateDto?> GetUserByEmailAsync(string email);
        Task<IEnumerable<UserCreateUpdateDto>> GetAllUsersAsync();
        Task AddUserAsync(UserCreateUpdateDto user);
        Task UpdateUserAsync(UserCreateUpdateDto user);
        Task DeleteUserAsync(int id);
        Task<bool> UserExistsAsync(string email);
    }
}
