using KindergartenSystem.Data;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Services.Mapping;
using KindergartenSystem.Web.ViewModels.Home;
using Microsoft.EntityFrameworkCore;

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
                .Include(x => x.Images).To<IndexViewModel>()
                .FirstAsync();
            var image = await _dbContext.Image.FirstOrDefaultAsync(x => x.KindergartenId == kindergarten.Id);
            kindergarten.ImageUrl = image.Url;
        
            return kindergarten;

        }

        public async Task<IEnumerable<ImageViewModel>> AboutInfoAsync()
        {
            IEnumerable<ImageViewModel> aboutInfo =
                            await _dbContext.Image.Take(3).To<ImageViewModel>()
                            .ToArrayAsync();
            return aboutInfo;
        }
    }
}
