using KindergartenSystem.Data;
using KindergartenSystem.Data.Models;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Web.ViewModels.ClassGroup;
using Microsoft.AspNetCore.Mvc;
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
                                Name = x.Title
                            }).ToArrayAsync();
            
            return getClassGroups;
        }
    }
}
