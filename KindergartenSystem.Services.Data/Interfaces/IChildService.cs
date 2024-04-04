using KindergartenSystem.Services.Data.Models.Child;
using KindergartenSystem.Web.ViewModels.Child;

namespace KindergartenSystem.Services.Data.Interfaces
{
    public interface IChildService
    {
        Task<string> CreateChildAsync(ChildFormModel model, string parentId);
        Task<AllChildrenServiceModel> AllChildrenAsync(AllChildrenByGroupQueryModel model);
        Task<IEnumerable<AllChildrenByGroupViewModel>> AllByTeachersAsync(string teacherId);
        Task<IEnumerable<AllChildrenByGroupViewModel>> AllByParentsAsync(string parentId);
        Task<ChildDetailsViewModel> GetChildDetailsAsync(string childId);
        Task<bool> ExistsById(string id);
        Task<ChildFormModel> GetChildForEditAsync(string id);
        Task<bool> IsTeacherOfTheGroup(string teacherId, string childId);
        Task EditChildInfoAsync(string childId, ChildFormModel model);
        Task<ChildDeleteInfoViewModel> GetDeleteChildInfoAsync(string childId);
        Task DeleteChildAsync(string childId);
    }
}
