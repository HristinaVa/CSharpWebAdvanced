using KindergartenSystem.Data;
using KindergartenSystem.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace KindergartenSystem.Services.Data
{
    public class TeacherService : ITeacherService
    {
        private readonly KindergartenDbContext _dbContext;

        public TeacherService(KindergartenDbContext dbContext)
        {
            _dbContext = dbContext;
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
