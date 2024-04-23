using KindergartenSystem.Data;
using KindergartenSystem.Data.Models;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Services.Data.Models.Teacher;
using KindergartenSystem.Services.Mapping;
using KindergartenSystem.Web.ViewModels.Child;
using KindergartenSystem.Web.ViewModels.Teacher;
using KindergartenSystem.Web.ViewModels.Workshop;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            IQueryable<Teacher> teachersQuery = _dbContext.Teachers.Where(x => x.IsWorking).AsQueryable();
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
            var teacher = await _dbContext.Teachers.Where(x => x.IsWorking).FirstOrDefaultAsync(x => x.UserId == userId);
            if (teacher == null)
            {
                return null;
            }
            return teacher.Id.ToString();
        }

        public async Task<bool> IsChildFromTheGroup(string userId, string childId)
        {
            var teacher = await _dbContext.Teachers.Where(x => x.IsWorking).Include(a => a.ClassGroup)
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
                .Teachers.Where(x => x.IsWorking)
                .AnyAsync(a => a.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task<bool> TeacherExistsByUserId(string userId)
        {
            bool result = await _dbContext
                .Teachers.Where(x => x.IsWorking)
                .AnyAsync(a => a.UserId == userId);

            return result;
        }
        public async Task<bool> TeacherExistsById(string id)
        {
            bool result = await _dbContext
                .Teachers.Where(x => x.IsWorking)
                .AnyAsync(a => a.Id.ToString() == id);

            return result;
        }
        public async Task<TeacherFormModel> GetTeacherForEditAsync(string id)
        {
            var teacher = await _dbContext.Teachers           
           .Where(x =>x.IsWorking && x.Id.ToString() == id).To<TeacherFormModel>()
           .FirstAsync();
            
            return teacher;

        }
        public async Task EditTeacherInfoAsync(string id, TeacherFormModel model)
        {
            var teacher = await _dbContext.Teachers.Where(x => x.IsWorking).FirstAsync(x => x.Id.ToString() == id);
            teacher.Name = model.Name;
            teacher.PhoneNumber = model.PhoneNumber;
            teacher.EmailAddress = model.EmailAddress;
            teacher.ImageUrl = model.ImageUrl;
            teacher.ClassGroupId = model.ClassGroupId;

            await _dbContext.SaveChangesAsync();


        }
        public async Task<TeacherDeleteInfoViewModel> GetDeleteTeacherInfoAsync(string id)
        {
            var teacher = await _dbContext.Teachers.Include(x => x.ClassGroup).Where(x => x.IsWorking).FirstAsync(x => x.Id.ToString() == id);

            return new TeacherDeleteInfoViewModel
            {
                Name = teacher.Name,
                ClassGroup = teacher.ClassGroup.Title,
                ImageUrl = teacher.ImageUrl,
                PhoneNumber = teacher.PhoneNumber,
            };
        }
        public async Task DeleteTeacherAsync(string id)
        {
            var teacher = await _dbContext.Teachers.Where(x => x.IsWorking)
                .FirstAsync(x => x.Id.ToString() == id);

            teacher.IsWorking = false;

            await _dbContext.SaveChangesAsync();
        }
        public async Task<string> AddWorkshopAsync(WorkshopFormModel model, string childId)
        {
            Workshop workshop = AutoMapperConfig.MapperInstance.Map<Workshop>(model);
            workshop.ChildId = Guid.Parse(childId);

            await _dbContext.Workshops.AddAsync(workshop);
            await _dbContext.SaveChangesAsync();

            return workshop.Id.ToString();
        }


    }
}

