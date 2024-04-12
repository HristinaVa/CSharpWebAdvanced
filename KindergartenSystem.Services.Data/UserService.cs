using KindergartenSystem.Data;
using KindergartenSystem.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindergartenSystem.Services.Data
{
    public class UserService : IUserService
    {
        private readonly KindergartenDbContext _dbContext;
        public UserService(KindergartenDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string?> UserNameAsync(string email)
        {
            var user = await _dbContext.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }
            return $"{user.FirstName} {user.LastName}";
        }
    }
}
