using KindergartenSystem.Data;
using KindergartenSystem.Data.Models;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Web.ViewModels.Parent;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace KindergartenSystem.Services.Data
{
    public class ParentService : IParentService
    {
        private readonly KindergartenDbContext _dbContext;

        public ParentService(KindergartenDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(string userId, IAmParentFormModel model)
        {
            Parent newParent = new Parent()
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                PhoneNumberSecond = model.PhoneNumberSecond,
                Address = model.Address,
                UserId = userId,
                EmailAddress = model.EmailAddress,
            };

            await _dbContext.Parents.AddAsync(newParent);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ParentExistsByPhoneNumberAsync(string phoneNumber)
        {
            bool result = await _dbContext
                .Parents
                .AnyAsync(a => a.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task<bool> ParentExistsByUserId(string userId)
        {
            bool result = await _dbContext
                .Parents
                .AnyAsync(a => a.UserId == userId);

            return result;
        }
        public async Task<string> GetParentIdByUserAsync(string userId)
        {
            var parent = await _dbContext.Parents.FirstOrDefaultAsync(x => x.UserId == userId);
            if (parent == null)
            {
                return null;
            }
            return parent.Id.ToString();
        }

        public async Task<string> GetParentIdByPhoneAsync(string phone)
        {
            var parent = await _dbContext.Parents.FirstOrDefaultAsync(x => x.PhoneNumber == phone);
            if (parent == null)
            {
                return null;
            }
            return parent.Id.ToString();
            
        }
    }
}
