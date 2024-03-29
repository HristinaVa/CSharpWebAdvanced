using KindergartenSystem.Data;
using KindergartenSystem.Services.Data.Interfaces;
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
        public async Task<IEnumerable<int>> AllAgeGroupNumbersAsync()
        {
            IEnumerable<int> ageGroupNumbers = await _dbContext.AgeGroups
                .Select(x => x.Number).ToArrayAsync();
            return ageGroupNumbers;
        }
    }
}
