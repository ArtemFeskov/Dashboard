using Dashboard.Data.Data.Interfaces;
using Dashboard.Data.Data.Models;
using Dashboard.Data.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Servises
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ServiceResponse> RegisterUserAsync(RegisterUserVM model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return new ServiceResponse
                {
                    Message = "Passwor and Confirm password don`t match",
                    IsSuccess = false
                };
            }

            AppUser newUser = new AppUser
            {
                Email = model.Emeil,
                UserName = model.Emeil 
            };

            var result = await _userRepository.RegisterUserAsync(newUser, model.Password);

            if (result.Succeeded)
            {
                return new ServiceResponse
                {
                    Message = $"User {model.Emeil} succsessfully created!",
                    IsSuccess = true
                };
            }
            else
            {
                return new ServiceResponse
                {
                    Message = "Error user not created!",
                    IsSuccess = false,
                    Errors = result.Errors.Select(e => e.Description)
                };
            }
        }
    }
}
