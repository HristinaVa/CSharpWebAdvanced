using KindergartenSystem.Data;
using KindergartenSystem.Data.Models;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Web.ViewModels.Child;
using static KindergartenSystem.Common.EntityValidationConstants.Child;

namespace KindergartenSystem.Services.Data
{
    public class ChildService : IChildService
    {
        private readonly KindergartenDbContext _dbContext;
        public ChildService(KindergartenDbContext dbContext)
        {
            _dbContext = dbContext;   
        }
        public async Task CreateChildAsync(ChildFormModel model, string parentId)
        {
            Child child = new Child()
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                ImageUrl = model.ImageUrl,
                ParentId = Guid.Parse(parentId),
                ClassGroupId = model.ClassGroupId
            };

            await _dbContext.Children.AddAsync(child);
            await _dbContext.SaveChangesAsync();
            
        }
    }
}
