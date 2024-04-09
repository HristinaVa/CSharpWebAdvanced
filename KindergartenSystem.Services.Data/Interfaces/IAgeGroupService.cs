using KindergartenSystem.Web.ViewModels.AgeGroup;

namespace KindergartenSystem.Services.Data.Interfaces
{
    public interface IAgeGroupService
    {
        Task<IEnumerable<AgeGroupViewModel>> AllAgeGroupNumbersAsync();
        Task<IEnumerable<AllAgeGroupsViewModel>> AllAgeGroupsAsync(int id);

    }
}
