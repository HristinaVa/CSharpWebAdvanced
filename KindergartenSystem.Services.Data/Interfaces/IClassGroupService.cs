using KindergartenSystem.Web.ViewModels.ClassGroup;

namespace KindergartenSystem.Services.Data.Interfaces
{
    public interface IClassGroupService
    {
        Task<IEnumerable<ClassGroupSelectModel>> GetClassGroupsAsync();
        Task<bool> ExistsById(int id);
        Task<IEnumerable<string>> AllClassGroupsTitlesAsync();
        Task<ClassGroupDetailsViewModel> GetDetailsAsync(int id);
    }
}
