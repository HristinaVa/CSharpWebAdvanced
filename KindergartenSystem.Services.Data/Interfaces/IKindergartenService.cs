using KindergartenSystem.Web.ViewModels.Home;

namespace KindergartenSystem.Services.Data.Interfaces
{
    public interface IKindergartenService
    {
        Task <IEnumerable<ImageViewModel>> AboutInfoAsync();
    }
}
