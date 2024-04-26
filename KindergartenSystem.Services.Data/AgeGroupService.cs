using KindergartenSystem.Services.Mapping;
using KindergartenSystem.Data;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Web.ViewModels.AgeGroup;
using KindergartenSystem.Web.ViewModels.ClassGroup;
using Microsoft.EntityFrameworkCore;

namespace KindergartenSystem.Services.Data
{
    public class AgeGroupService : IAgeGroupService
    {
        private readonly KindergartenDbContext _dbContext;
        public AgeGroupService(KindergartenDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<AgeGroupViewModel>> AllAgeGroupNumbersAsync()
        {
            IEnumerable<AgeGroupViewModel> ageGroupNumbers = await _dbContext.AgeGroups
                .Select(x => new AgeGroupViewModel
                {
                    Id = x.Id,
                    Number = x.Number.ToString(),
                    ClassGroupNames = x.ClassGroups.Select(x => x.Title).ToArray()
                }).ToListAsync();
            return ageGroupNumbers;
        }

        public async Task<IEnumerable<AllAgeGroupsViewModel>> AllAgeGroupsAsync(int id)
        {
            var ageGroups = await _dbContext.AgeGroups.Where(x => x.KindergartenId == id).To<AllAgeGroupsViewModel>().ToArrayAsync();
           
            return ageGroups;
        }

        public async Task<bool> ExistsById(int id)
        {
            bool result = await _dbContext.AgeGroups.AnyAsync(x => x.Id == id);
            return result;
        }

        public async Task<AgeGroupDetailsViewModel> GetAgeGroupDetailsAsync(int id)
        {
            var group = await _dbContext.AgeGroups
            .Include(x => x.ClassGroups)
               .Where(x => x.Id == id).FirstAsync();
            
            var classGroups = await _dbContext.ClassGroups.Where(x => x.AgeGroupId == id).Select(x => new ClassGroupSelectModel
            {
                Id = x.Id,
                Title = x.Title
            }).ToArrayAsync();

            AgeGroupDetailsViewModel model = new AgeGroupDetailsViewModel
            {
                Id = group.Id,
                Number = group.Number,
            };
            if (group.ClassGroups.Any())
            {
                model.ClassGroupsCount = group.ClassGroups.Count();
                model.ClassGroups = classGroups;

            }
                


            return model;
        }
        public async Task<IEnumerable<AllAgeGroupsViewModel>> GetAgeGroupsAsync()
        {
            IEnumerable<AllAgeGroupsViewModel> getAgeGroups = await _dbContext.AgeGroups.To<AllAgeGroupsViewModel>()
                           .ToArrayAsync();

            return getAgeGroups;
        }
    }
}
