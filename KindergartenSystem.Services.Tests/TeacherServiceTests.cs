
using KindergartenSystem.Data;

using KindergartenSystem.Services.Data;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Web.ViewModels.Teacher;
using Microsoft.EntityFrameworkCore;
using static KindergartenSystem.Services.Tests.DataSeed;
namespace KindergartenSystem.Services.Tests
{
    public class TeacherServiceTests
    {
        private KindergartenDbContext _context;
        private DbContextOptions<KindergartenDbContext> _options;
        private ITeacherService teacherService;
        private IChildService _childService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _options = new DbContextOptionsBuilder<KindergartenDbContext>().UseInMemoryDatabase("KindergartenServiceInMemory" + Guid.NewGuid().ToString()).Options;
            _context = new KindergartenDbContext(_options);

            _context.Database.EnsureCreated();

            SeedData(_context);
            teacherService = new TeacherService(_context);
            _childService = new ChildService(_context);

        }

        [Test]
        public async Task TeacherExistsByUserIdReturnTrueWhenExists()
        {
            var teacherUserId = TeacherUser.Id.ToString();

            bool result = await this.teacherService.TeacherExistsByUserId(teacherUserId);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task TeacherExistsByUserIdReturnFalseWhenMissing()
        {
            var teacherUserId = ParentUser.Id.ToString();

            bool result = await teacherService.TeacherExistsByUserId(teacherUserId);

            Assert.IsFalse(result);
        }
        [Test]
        public async Task TeacherExistsByPhoneReturnTrueWhenExists()
        {
            var teacherPhone = Teacher.PhoneNumber;

            bool result = await teacherService.TeacherExistsByPhoneNumberAsync(teacherPhone);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task TeacherExistsByPhoneReturnFalseWhenMissing()
        {
            var teacherPhone = ParentUser.PhoneNumber;

            bool result = await teacherService.TeacherExistsByPhoneNumberAsync(teacherPhone);

            Assert.IsFalse(result);
        }
        [Test]
        public async Task IsTheTeacherOfTheChildReturnsTrueWhenSheIs()
        {
            var teacherUserId = TeacherUser.Id.ToString();
            var childId = Child.Id.ToString();

            bool result = await teacherService.IsChildFromTheGroup(teacherUserId, childId);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task IsTheTeacherOfTheChildReturnsFalseWhenSheIsNot()
        {
            var teacherUserId = ParentUser.Id.ToString();
            var childId = Child.Id.ToString();

            bool result = await teacherService.IsChildFromTheGroup(teacherUserId, childId);

            Assert.IsFalse(result);
        }
        [Test]
        public async Task GetTeacherByUserIdReturnsTeacherIdWhenTeacherExists()
        {
            var teacherUserId = TeacherUser.Id.ToString();
            var expectedTeacherId = Teacher.Id.ToString();
            var result = await teacherService.GetTeacherByUserId(teacherUserId);
            Assert.AreEqual(expectedTeacherId, result);

        }
        [Test]
        public async Task GetTeacherByUserIdReturnsNullWhenTeacherDoesNotExist()
        {
            var falseTeacherUserId = ParentUser.Id.ToString();
            var result = await teacherService.GetTeacherByUserId(falseTeacherUserId);
            Assert.IsNull(result);

        }
      
        [Test]
        public async Task EditTeacherInfoWhenTeacherExists()
        {
            var teacherId = Teacher.Id.ToString(); 
            var updatedTeacherName = "Updated Teacher Name";
            var updatedPhoneNumber = "+359222334455";
            var updatedEmailAddress = "updated@email.com"; 
            var updatedImageUrl = "https://t3.ftcdn.net/jpg/00/63/41/20/360_F_63412065_tVAWzIWl9wE7l73MWUVieyGg1QlzhQCR.jpg";
            var updatedClassGroupId = 2; 
            var model = new TeacherFormModel
            {
                Name = updatedTeacherName,
                PhoneNumber = updatedPhoneNumber,
                EmailAddress = updatedEmailAddress,
                ImageUrl = updatedImageUrl,
                ClassGroupId = updatedClassGroupId
            };

            await teacherService.EditTeacherInfoAsync(teacherId, model);

            Assert.AreEqual(updatedTeacherName, Teacher.Name); 
            Assert.AreEqual(updatedPhoneNumber, Teacher.PhoneNumber);
            Assert.AreEqual(updatedEmailAddress, Teacher.EmailAddress); 
            Assert.AreEqual(updatedImageUrl, Teacher.ImageUrl); 
            Assert.AreEqual(updatedClassGroupId, Teacher.ClassGroupId); 
        }
        [Test]
        public async Task SetsIsWorkingToFalseWhenTeacherExists()
        {
            var teacherId = Teacher.Id.ToString(); 
            
            await teacherService.DeleteTeacherAsync(teacherId);

            Assert.IsFalse(Teacher.IsWorking); 
        }
        


    }

}
