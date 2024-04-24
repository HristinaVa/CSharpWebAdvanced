using KindergartenSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KindergartenSystem.Data.Configurations
{
    public class ImageEntityConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(GenerateImages());
        }
        private Image[] GenerateImages()
        {
            ICollection<Image> images = new HashSet<Image>();
            Image image;

            image = new Image()
            {
                Url = "https://as2.ftcdn.net/v2/jpg/05/95/07/45/1000_F_595074521_hpNDWQChd0dx3pKmFXoX6VNukn2PNOGz.jpg", //"https://landezine.com/wp-content/uploads/2023/06/13-3-1270x846.jpg",
                KindergartenId = 1
                
            };

            images.Add(image);
            
            image = new Image()
            {
                Url = "https://as1.ftcdn.net/v2/jpg/04/50/55/90/1000_F_450559026_CTK0vyFVr8d7ryOtZFrptDwT4mWP2IVf.jpg",//"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTaUwQTx7J17GWtmvOuoaecCfBw7c-sUmOTk1xjm0IQQxjR2CZH0154QwUT103frsZBezI&usqp=CAU",
                KindergartenId = 1

            };

            images.Add(image);
            image = new Image()
            {
                Url = "https://as2.ftcdn.net/v2/jpg/02/44/32/23/1000_F_244322317_eantlk9EzUZwcQ68xornkV4hxnGKz16T.jpg", //"https://file2.okorder.com/attach/2017/01/09/b6e37ea332d65dca1d4172df440fcc72.jpg",
                KindergartenId = 1

            };

            images.Add(image);

            return images.ToArray();
        }
    }
}

