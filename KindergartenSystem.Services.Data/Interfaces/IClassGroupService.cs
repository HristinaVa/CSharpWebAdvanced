using KindergartenSystem.Web.ViewModels.ClassGroup;

namespace KindergartenSystem.Services.Data.Interfaces
{
    public interface IClassGroupService
    {
        Task<IEnumerable<ClassGroupSelectModel>> GetClassGroupsAsync();
    }
}
