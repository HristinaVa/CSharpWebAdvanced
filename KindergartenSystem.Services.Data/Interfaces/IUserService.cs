using KindergartenSystem.Web.ViewModels.ClassGroup;
using KindergartenSystem.Web.ViewModels.Teacher;
using KindergartenSystem.Web.ViewModels.User;
using Microsoft.EntityFrameworkCore;

namespace KindergartenSystem.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<string?> UserNameAsync(string email);

        Task<string?> UserNameByIdAsync(string id);

        Task<IEnumerable<UserViewModel>> GetUsersAsync();
        Task<bool> TeacherAlreadyExistsAsync(string userId);
        Task<bool> UserExistsByIdAsync(string userId);
        Task<IEnumerable<ClassGroupSelectModel>> GetClassGroupsAsync();
        Task<bool> ClassGroupExistsById(int id);
       
        Task CreateTeacherAsync(string userId, CreateTeacherFromUserFormModel model);

    }
}
