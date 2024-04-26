using KindergartenSystem.Web.ViewModels.AgeGroup;
using KindergartenSystem.Web.ViewModels.Child;

namespace KindergartenSystem.Services.Data.Interfaces
{
    public interface IAgeGroupService
    {
        Task<IEnumerable<AgeGroupViewModel>> AllAgeGroupNumbersAsync();
        Task<IEnumerable<AllAgeGroupsViewModel>> AllAgeGroupsAsync(int id);
        Task<bool> ExistsById(int id);
        Task<AgeGroupDetailsViewModel> GetAgeGroupDetailsAsync(int id);
        Task<IEnumerable<AllAgeGroupsViewModel>> GetAgeGroupsAsync();



    }
}
