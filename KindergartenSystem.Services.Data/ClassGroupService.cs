using KindergartenSystem.Data;
using KindergartenSystem.Services.Data.Interfaces;
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
        public async Task<IEnumerable<ClassGroupSelectModel>> GetClassGroupsAsync()
        {
            IEnumerable<ClassGroupSelectModel> getClassGroups = await _dbContext.ClassGroups
                            .Select(x => new ClassGroupSelectModel()
                            {
                                Id = x.Id,
                                Name = x.Title
                            }).ToArrayAsync();
            return getClassGroups;
        }
    }
}
