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
    public class KindergartenEntityConfiguration : IEntityTypeConfiguration<Kindergarten>
    {
        public void Configure(EntityTypeBuilder<Kindergarten> builder)
        {
            builder.HasData(GenerateKindergarten());
        }
        private Kindergarten[] GenerateKindergarten()
        {
            ICollection<Kindergarten> kindergartens = new HashSet<Kindergarten>();
            Kindergarten kindergarten;
            
            kindergarten = new Kindergarten()
            {
                Id = 1,
                Name = "Zaio Baio",
                PhoneNumber = "+359878888888",
                Address = "Varna, ul.Morska 11",
                Principal = "P.Petrova",
                EmailAddress = "zaiobaio@zaiobaio.com"
            };
           
            kindergartens.Add(kindergarten);
           
            return kindergartens.ToArray();
        }
    }
}
