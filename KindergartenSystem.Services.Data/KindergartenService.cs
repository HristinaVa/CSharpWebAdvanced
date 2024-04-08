using KindergartenSystem.Data;
using KindergartenSystem.Data.Models;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Web.ViewModels.Home;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await _dbContext.Kindergartens.AnyAsync(x => x.Id == id);
            return result;
        }

        public async Task<IndexViewModel> AboutAsync()
        {
            var kindergarten = await _dbContext.Kindergartens
                .Include(x => x.Images)
                //.ThenInclude(x => x.Url)
                .FirstAsync();
            var image = kindergarten.Images.Select(x => x.Url).FirstOrDefault();
            var model = new IndexViewModel
            {
                Id = kindergarten.Id,
                Name = kindergarten.Name,
                Address = kindergarten.Address,
                EmailAddress = kindergarten.EmailAddress,
                Principal = kindergarten.Principal,
                PhoneNumber = kindergarten.PhoneNumber,
                ImageUrl = image
                


            };
            return model;

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
