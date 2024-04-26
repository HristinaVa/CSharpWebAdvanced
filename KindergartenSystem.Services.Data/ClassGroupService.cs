using KindergartenSystem.Data;
using KindergartenSystem.Data.Models;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Services.Mapping;
using KindergartenSystem.Web.ViewModels.Child;
using KindergartenSystem.Web.ViewModels.ClassGroup;
using Microsoft.EntityFrameworkCore;

namespace KindergartenSystem.Services.Data
{
    public class ClassGroupService : IClassGroupService
    {
        private readonly KindergartenDbContext _dbContext;
        public ClassGroupService(KindergartenDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
       
        public async Task<IEnumerable<string>> AllClassGroupsTitlesAsync()
        {
            
            IEnumerable<string> classGroupTitles = await _dbContext.ClassGroups
                .Select(x => x.Title).ToArrayAsync();    
            
            return classGroupTitles;
        }

        public async Task<bool> ExistsById(int id)
        {
            var result = await _dbContext.ClassGroups.AnyAsync(x => x.Id == id);
            
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

        public async Task<ClassGroupDetailsViewModel> GetDetailsAsync(int id)
        {
            var group = await _dbContext.ClassGroups.Include(x =>x.Teachers).Where(x => x.Id == id).FirstAsync();
            var model = new ClassGroupDetailsViewModel()
            {
                Id = group.Id,
                AgeGroup = group.AgeGroupId,
                Title = group.Title
            };
            if (group.Teachers.Where(x => x.IsWorking).Any())
            {
                model.TeachersName = group.Teachers.Select(x => x.Name).ToArray();
                model.Phone = group.Teachers.Select(x => x.PhoneNumber).FirstOrDefault();
            }
            else
            {
                model.TeachersName = null;
                model.Phone = null;
            }
            return model;
        }
        public async Task<int> CreateClassGroupAsync(ClassGroupViewModel model)
        {
            ClassGroup classGroup = new ClassGroup()
            {
                Title = model.Title,
                AgeGroupId = model.AgeGroupId,

            };

            await _dbContext.ClassGroups.AddAsync(classGroup);
            await _dbContext.SaveChangesAsync();
            
            return classGroup.Id;
        }


    }
}
