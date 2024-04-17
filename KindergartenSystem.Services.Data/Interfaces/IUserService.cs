using KindergartenSystem.Web.ViewModels.User;

namespace KindergartenSystem.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<string?> UserNameAsync(string email);

        Task<string?> UserNameByIdAsync(string id);

        Task<IEnumerable<UserViewModel>> GetUsersAsync();
        
    }
}
