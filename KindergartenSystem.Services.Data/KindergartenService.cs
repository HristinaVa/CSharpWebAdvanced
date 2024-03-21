using KindergartenSystem.Data;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Web.ViewModels.Home;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindergartenSystem.Services.Data
{
    public class KindergartenService : IKindergartenService
    {
        private readonly KindergartenDbContext _dbContext;
        public KindergartenService(KindergartenDbContext dbContext)
        {
            _dbContext = dbContext;   
        }

        public async Task<IEnumerable<ImageViewModel>> AboutInfoAsync()
        {
            IEnumerable<ImageViewModel> aboutInfo =
                            await _dbContext.Image.Select(x => new ImageViewModel
                            {
                                Id = x.Id.ToString(),
                                Url = x.Url,
                                KindergardenId = x.KindergartenId,
                               Title = x.Kindergarten.Name

                            }).Take(3)
                            .ToArrayAsync();
            return aboutInfo;
        }
    }
}
