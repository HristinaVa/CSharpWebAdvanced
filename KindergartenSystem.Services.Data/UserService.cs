using KindergartenSystem.Data;
using KindergartenSystem.Data.Models;
using KindergartenSystem.Data.Models.Enums;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Services.Mapping;
using KindergartenSystem.Web.ViewModels.ClassGroup;
using KindergartenSystem.Web.ViewModels.Parent;
using KindergartenSystem.Web.ViewModels.Teacher;
using KindergartenSystem.Web.ViewModels.User;
using Microsoft.AspNetCore.Http;
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

        public async Task CreateTeacherAsync(string userId, CreateTeacherFromUserFormModel model)
        {
            Teacher teacher = new Teacher()
            {
                EmailAddress = model.EmailAddress,
                ImageUrl = model.ImageUrl,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                UserId = userId,
                ClassGroupId = model.ClassGroupId,

            };
            await _dbContext.Teachers.AddAsync(teacher);
            await _dbContext.SaveChangesAsync();
           
        }

        public async Task<bool> TeacherAlreadyExistsAsync(string userId)
        {
            
            bool result = await _dbContext
                .Teachers
                .AnyAsync(a => a.UserId == userId);

            return result;
           
        }

        public async Task<bool> UserExistsByIdAsync(string userId)
        {
            var result = await _dbContext.Users.AnyAsync(x => x.Id == userId);
            return result;
            

        }

        public async Task<IEnumerable<ClassGroupSelectModel>> GetClassGroupsAsync()
        {
            IEnumerable<ClassGroupSelectModel> getClassGroups = await _dbContext.ClassGroups
                            .Select(x => new ClassGroupSelectModel()
                            {
                                Id = x.Id,
                                Title = x.Title
                            }).ToArrayAsync();

            return getClassGroups;
        }

        public async Task<bool> ClassGroupExistsById(int id)
        {
            var result = await _dbContext.ClassGroups.AnyAsync(x => x.Id == id);

            return result;
        }

        public async Task<IEnumerable<PendingParentsViewModel>> GetPendingParentsAsync()
        {
            var parents = await _dbContext.Parents.Where(p => p.Status == ParentStatus.Pending).Select(x => new PendingParentsViewModel()
            {
                Name = x.Name,
                EmailAddress = x.EmailAddress,
                PhoneNumber = x.PhoneNumber,
                Status = x.Status.ToString(),
                Id = x.Id.ToString()
            }).ToArrayAsync();
            return parents;
        }

        public async Task<bool> UpdateParentStatusAsync(string parentId, ParentStatus newStatus)
        {
            var parent = await _dbContext.Parents.Where(x => x.Id == Guid.Parse(parentId)).FirstOrDefaultAsync();

            if (parent == null)
            {
                return false;
            }

            parent.Status = newStatus;

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
        
    


