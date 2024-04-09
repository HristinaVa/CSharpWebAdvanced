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
            var ageGroups = await _dbContext.AgeGroups.Where(x => x.KindergartenId == id).Select(x => new AllAgeGroupsViewModel
            {
                Id = x.Id,
                Number = x.Number.ToString(),

            }).ToArrayAsync();
            return ageGroups;
        }
    }
}
