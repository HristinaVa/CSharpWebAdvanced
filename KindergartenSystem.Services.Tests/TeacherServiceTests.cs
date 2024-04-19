using KindergartenSystem.Data;
using KindergartenSystem.Services.Data;
using KindergartenSystem.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using static KindergartenSystem.Services.Tests.DataSeed;
namespace KindergartenSystem.Services.Tests
{
    public class TeacherServiceTests
    {
        private KindergartenDbContext _context;
        private DbContextOptions<KindergartenDbContext> _options;
        private ITeacherService _teacherService;
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _options = new DbContextOptionsBuilder<KindergartenDbContext>().UseInMemoryDatabase("KindergartenServiceInMemory" + Guid.NewGuid().ToString()).Options;
            _context = new KindergartenDbContext(_options);

            _context.Database.EnsureCreated();

            SeedData(_context);
            _teacherService = new TeacherService(_context);

        }

        [Test]
        public async Task TeacherExistsByUserIdReturnTrueWhenExists()
        {
            var teacherUserId = TeacherUser.Id.ToString();
            
            bool result = await _teacherService.TeacherExistsByUserId(teacherUserId);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task TeacherExistsByUserIdReturnFalseWhenMissing()
        {
            var teacherUserId = ParentUser.Id.ToString();

            bool result = await _teacherService.TeacherExistsByUserId(teacherUserId);

            Assert.IsFalse(result);
        }

    }
}