using KindergartenSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Url = "https://landezine.com/wp-content/uploads/2023/06/13-3-1270x846.jpg",
                KindergartenId = 1
                
            };

            images.Add(image);
            
            image = new Image()
            {
                Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTaUwQTx7J17GWtmvOuoaecCfBw7c-sUmOTk1xjm0IQQxjR2CZH0154QwUT103frsZBezI&usqp=CAU",
                KindergartenId = 1

            };

            images.Add(image);
            image = new Image()
            {
                Url = "https://file2.okorder.com/attach/2017/01/09/b6e37ea332d65dca1d4172df440fcc72.jpg",
                KindergartenId = 1

            };

            images.Add(image);

            return images.ToArray();
        }
    }
}

