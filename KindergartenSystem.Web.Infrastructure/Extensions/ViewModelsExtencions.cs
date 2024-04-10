using KindergartenSystem.Web.ViewModels.ClassGroup.Interfaces;

namespace KindergartenSystem.Web.Infrastructure.Extensions
{
    public static class ViewModelsExtencions
    {
        public static string GetUrlInfomation(IClassGroupModel model)
        {
            return model.Title.ToLower();
        }
    }
}
