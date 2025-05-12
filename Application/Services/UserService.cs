using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<UserCreateUpdateDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            var userCreateUpdate = _mapper.Map<UserCreateUpdateDto>(user);
            return userCreateUpdate;

        }
        public async Task<UserCreateUpdateDto?> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            var userCreateUpdate = _mapper.Map<UserCreateUpdateDto>(user);
            return userCreateUpdate;

        }
        public async Task<IEnumerable<UserCreateUpdateDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();

            var listUserCreateUpdate = _mapper.Map<IEnumerable<UserCreateUpdateDto>>(users);
            return listUserCreateUpdate;
        }
        public async Task AddUserAsync(UserCreateUpdateDto userDto)
        {
            if (await _userRepository.UserExistsAsync(userDto.Email))
                throw new Exception("El usuario con este correo electrónico ya existe.");

            var user = _mapper.Map<User>(userDto);
            user.CreatedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;

            await _userRepository.AddUserAsync(user);
        }
        public async Task UpdateUserAsync(UserCreateUpdateDto userDto)
        {
            if (userDto.Id != null)
            {
                var existingUser = await _userRepository.GetUserByIdAsync((int)userDto.Id);

                if (existingUser != null)
                {
                    _mapper.Map(userDto, existingUser);
                    existingUser.UpdatedAt = DateTime.UtcNow;

                    await _userRepository.UpdateUserAsync(existingUser);
                }
                else
                {
                    throw new Exception("El usuario no existe.");
                }
            }
            else
            {
                throw new Exception("No se puede verificar el Id del usuario que desea modificar.");
            }
        }
        public async Task DeleteUserAsync(int id)
        {
            //Hacemos soft delete
            var existingUser = await _userRepository.GetUserByIdAsync(id);

            if (existingUser != null)
            {
                existingUser.Status = false;
                existingUser.UpdatedAt = DateTime.UtcNow;

                await _userRepository.UpdateUserAsync(existingUser);
            }
            else
            {
                throw new Exception("El usuario no existe.");
            }
        }
        public async Task<bool> UserExistsAsync(string email)
        {
            return await _userRepository.UserExistsAsync(email);
        }
    }
}
