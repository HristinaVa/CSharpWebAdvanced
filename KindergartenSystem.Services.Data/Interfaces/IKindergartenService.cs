using KindergartenSystem.Web.ViewModels.Home;

namespace KindergartenSystem.Services.Data.Interfaces
{
    public interface IKindergartenService
    {
        Task <IEnumerable<ImageViewModel>> AboutInfoAsync();
        Task <IndexViewModel> AboutAsync();
        //public Task<bool> ExistsByIdAsync(int id);
    }
}
