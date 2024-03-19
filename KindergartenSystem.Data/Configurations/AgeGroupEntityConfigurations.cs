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
    public class AgeGrooupEntityConfigurations : IEntityTypeConfiguration<AgeGroup>
    {
        public void Configure(EntityTypeBuilder<AgeGroup> builder)
        {
            builder
                .HasOne(a => a.Kindergarten)
                .WithMany(a => a.AgeGroups)
                .HasForeignKey(a => a.KindergartenId)
                .OnDelete(DeleteBehavior.Restrict);
           
            builder.HasData(GenerateAgeGroups());

        }
        private AgeGroup[] GenerateAgeGroups()
        {
            ICollection<AgeGroup> ageGroups = new HashSet<AgeGroup>();
            AgeGroup ageGroup;
            ageGroup = new AgeGroup()
            {
                Id = 1,
                Number = 1,
                KindergartenId = 1,

            };
            ageGroups.Add(ageGroup);
            ageGroup = new AgeGroup()
            {
                Id = 2,
                Number = 2,
                KindergartenId = 1,

            };
            ageGroups.Add(ageGroup); 
            ageGroup = new AgeGroup()
            {
                Id = 3,
                Number = 3,
                KindergartenId = 1,

            };
            ageGroups.Add(ageGroup); 
            ageGroup = new AgeGroup()
            {
                Id = 4,
                Number = 4,
                KindergartenId = 1,

            };
            ageGroups.Add(ageGroup);
            return ageGroups.ToArray();
        }
    }
}
