using KindergartenSystem.Data;
using KindergartenSystem.Data.Models;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Services.Data.Models.Teacher;
using KindergartenSystem.Web.ViewModels.Teacher;
using Microsoft.EntityFrameworkCore;

namespace KindergartenSystem.Services.Data
{
    public class TeacherService : ITeacherService
    {
        private readonly KindergartenDbContext _dbContext;

        public TeacherService(KindergartenDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AllTeachersServiceModel> AllTeachersAsync(AllTeachersQueryModel model)
        {
            IQueryable<Teacher> teachersQuery = _dbContext.Teachers.AsQueryable();
            if (model.AgeGroup != null)
            {
                teachersQuery = teachersQuery.Where(x => x.ClassGroup.AgeGroupId == model.AgeGroup);
            }
            if (!string.IsNullOrWhiteSpace(model.SearchText))
            {
                var wildCard = $"%{model.SearchText.ToLower()}%";
                teachersQuery = teachersQuery.Where
                    (x => EF.Functions.Like(x.Name, wildCard) ||
                EF.Functions.Like(x.ClassGroup.Title, wildCard) ||
                EF.Functions.Like(x.EmailAddress, wildCard) ||
                EF.Functions.Like(x.PhoneNumber, wildCard));
            }
            IEnumerable<AllTeachersViewModel> allTeachers = await teachersQuery
                .Skip((model.CurrentPage - 1) * model.TeachersPerPage)
                .Take(model.TeachersPerPage)
                .Select(x => new AllTeachersViewModel()
                {
                    Id = x.Id.ToString(),
                    Name = x.Name,
                    PhoneNumber = x.PhoneNumber,
                    EmailAddress = x.EmailAddress,
                    ClassGroupName = x.ClassGroup.Title,
                    ImageUrl = x.ImageUrl,
                })
                .OrderBy(x => x.ClassGroupName)
                .ThenBy(x => x.Name)
                .ToArrayAsync();
            int teachersTotal = teachersQuery.Count();

            return new AllTeachersServiceModel()
            {
                AllTeachersCount = teachersTotal,
                Teachers = allTeachers
            };
        }


        public async Task<string> GetTeacherByUserId(string userId)
        {
            var teacher = await _dbContext.Teachers.FirstOrDefaultAsync(x => x.UserId == userId);
            if (teacher == null)
            {
                return null;
            }
            return teacher.Id.ToString();
        }

        public async Task<bool> IsChildFromTheGroup(string userId, string childId)
        {
            var teacher = await _dbContext.Teachers.Include(a => a.ClassGroup)
                .ThenInclude(a => a.Children).FirstOrDefaultAsync(a => a.UserId == userId);
            if (teacher == null)
            {
                return false;
            }
            childId = childId.ToLower();
            return teacher.ClassGroup.Children.Any(x => x.Id.ToString() == childId);
        }

        public async Task<bool> TeacherExistsByPhoneNumberAsync(string phoneNumber)
        {
            bool result = await _dbContext
                .Teachers
                .AnyAsync(a => a.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task<bool> TeacherExistsByUserId(string userId)
        {
            bool result = await _dbContext
                .Teachers
                .AnyAsync(a => a.UserId == userId);

            return result;
        }
    }
}

