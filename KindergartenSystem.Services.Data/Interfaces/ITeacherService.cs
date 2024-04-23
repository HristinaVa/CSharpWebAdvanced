using KindergartenSystem.Services.Data.Models.Teacher;
using KindergartenSystem.Web.ViewModels.Child;
using KindergartenSystem.Web.ViewModels.Teacher;
using KindergartenSystem.Web.ViewModels.Workshop;

namespace KindergartenSystem.Services.Data.Interfaces
{
    public interface ITeacherService
    {
        Task<bool> TeacherExistsByUserId(string userId);
        Task<bool> TeacherExistsById(string id);
        Task<bool> TeacherExistsByPhoneNumberAsync(string phoneNumber);
        Task<string> GetTeacherByUserId(string userId);
        Task<bool> IsChildFromTheGroup(string userId, string childId);
        Task<AllTeachersServiceModel> AllTeachersAsync(AllTeachersQueryModel model);
        Task<TeacherFormModel> GetTeacherForEditAsync(string id);
        Task EditTeacherInfoAsync(string id, TeacherFormModel model);
        Task<TeacherDeleteInfoViewModel> GetDeleteTeacherInfoAsync(string id);
        Task DeleteTeacherAsync(string id);
        Task<string> AddWorkshopAsync(WorkshopFormModel model, string childtId);
    }
}
