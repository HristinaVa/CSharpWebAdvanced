using KindergartenSystem.Data;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Services.Mapping;
using KindergartenSystem.Web.ViewModels.User;
using Microsoft.EntityFrameworkCore;

namespace KindergartenSystem.Services.Data
{
    public class UserService : IUserService
    {
        private readonly KindergartenDbContext _dbContext;
        public UserService(KindergartenDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            List<UserViewModel> users = new List<UserViewModel>();
            IEnumerable<UserViewModel> teachers = await _dbContext.Teachers
                .Include(x => x.User).To<UserViewModel>().ToArrayAsync();
            users.AddRange(teachers);

            IEnumerable<UserViewModel> parents = await _dbContext.Parents
               .Include(x => x.User).To<UserViewModel>().ToArrayAsync();
            users.AddRange(parents);
            IEnumerable<UserViewModel> appUsers = await _dbContext.Users.Where(x => !_dbContext.Teachers.Any(u => u.UserId == u.Id.ToString()) && !_dbContext.Parents.Any(u => u.UserId == u.Id.ToString()))
               .To<UserViewModel>().ToArrayAsync();
            users.AddRange(appUsers);
            users = users.DistinctBy(x => x.Email).ToList();
            return users;
        }

        public async Task<string?> UserNameAsync(string email)
        {
            var user = await _dbContext.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
            if (user == null)
            {
                return string.Empty;
            }
            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<string?> UserNameByIdAsync(string id)
        {
            var user = await _dbContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (user == null)
            {
                return string.Empty;
            }
            return $"{user.FirstName} {user.LastName}";
        }
    }
}
