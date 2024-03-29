using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindergartenSystem.Services.Data.Interfaces
{
    public interface IAgeGroupService
    {
        Task<IEnumerable<int>> AllAgeGroupNumbersAsync();

    }
}
