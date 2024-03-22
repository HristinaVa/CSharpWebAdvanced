using KindergartenSystem.Web.ViewModels.Parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindergartenSystem.Services.Data.Interfaces
{
    public interface IParentService
    {
        Task<bool> ParentExistsByUserId(string userId);

        Task<bool> ParentExistsByPhoneNumberAsync(string phoneNumber);
        Task Create(string userId, IAmParentFormModel model);
    }
}
