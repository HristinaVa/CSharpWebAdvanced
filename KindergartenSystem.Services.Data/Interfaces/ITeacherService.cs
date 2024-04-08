using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindergartenSystem.Services.Data.Interfaces
{
    public interface ITeacherService
    {
        Task<bool> TeacherExistsByUserId(string userId);

        Task<bool> TeacherExistsByPhoneNumberAsync(string phoneNumber);
        Task<string> GetTeacherByUserId(string userId);
        Task<bool> IsChildFromTheGroup(string userId, string childId);

    }
}
