using KindergartenSystem.Services.Data.Models.Child;
using KindergartenSystem.Web.ViewModels.Child;

namespace KindergartenSystem.Services.Data.Interfaces
{
    public interface IChildService
    {
        Task CreateChildAsync(ChildFormModel model, string parentId);
        Task<AllChildrenServiceModel> AllChildrenAsync(AllChildrenByGroupQueryModel model);
        Task<IEnumerable<AllChildrenByGroupViewModel>> AllByTeachersAsync(string teacherId);
        Task<IEnumerable<AllChildrenByGroupViewModel>> AllByParentsAsync(string parentId);
    }
}
