using Dashboard.Data.Data.Interfaces;
using Dashboard.Data.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Data.Data.Classes
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        public UserRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager; 
        }
        public async Task<IdentityResult> RegisterUserAsync(AppUser model, string password)
        {
            IdentityResult result = await _userManager.CreateAsync(model, password);
            return result;
        }
    }
}
