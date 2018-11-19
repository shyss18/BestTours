﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BT.BusinessLogic.DTO;
using BT.BusinessLogic.Infrastructure;
using BT.BusinessLogic.Interface;
using BT.DataAccess.Interfaces;
using BT.Dom.Entities;
using Microsoft.AspNet.Identity;

namespace BT.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork Database { get; }

        public UserService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            User user = await Database.UserManager.FindByEmailAsync(userDto.Email);

            if (user == null)
            {
                user = new User { Email = userDto.Email, UserName = userDto.NickName, Amount = userDto.Amount, FirstName = userDto.FirstName, LastName = userDto.LastName, Tours = userDto.Tours };

                var result = await Database.UserManager.CreateAsync(user, userDto.Password);

                if (result.Errors.Count() > 0)
                {
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                }

                await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);

                ClientProfile profile = new ClientProfile { Id = user.Id, Email = userDto.Email, Name = userDto.NickName };
                Database.ClientManager.Create(profile);
                await Database.SaveAsync();

                return new OperationDetails(true, "Регистрация выполнена успешно", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким email уже существует", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claims = null;

            User user = await Database.UserManager.FindAsync(userDto.NickName, userDto.Password);

            if (user != null)
            {
                claims = await Database.UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
            }

            return claims;
        }

        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (var roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new Role { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }

            await Create(adminDto);
        }

        public async Task SetInitialDataAsync()
        {
            await SetInitialData(new UserDTO
            {
                Email = "admin@gmail.com",
                Password = "123456",
                Role = "admin",
                NickName = "Admin"
            }, new List<string> { "user", "admin" });
        }

        public UserDTO GetByNameUserDto(string name)
        {
            var user = Database.UserManager.Users.Where(m => m.UserName == name).Select(m => m).FirstOrDefault();

            UserDTO userDto = new UserDTO
            {
                NickName = user.UserName,
                Email = user.Email,
                Amount = user.Amount,
                Password = user.PasswordHash,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return userDto;
        }

        public User GetByNameUser(string name)
        {
            var user = Database.UserManager.Users.Where(m => m.UserName == name).Select(m => m).FirstOrDefault();

            return user;
        }

        public void UpdateUser(User user)
        {
            Database.UserManager.Update(user);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
