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
    public class ClassGroupEntityConfigurations : IEntityTypeConfiguration<ClassGroup>
    {
        public void Configure(EntityTypeBuilder<ClassGroup> builder)
        {
            builder
                .HasOne(c => c.AgeGroup)
                .WithMany(c => c.ClassGroups)
                .HasForeignKey(c => c.AgeGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(GenerateClassGroups());
        }
        private ClassGroup[] GenerateClassGroups()
        {
            ICollection<ClassGroup> classGroups = new HashSet<ClassGroup>();
            ClassGroup classGroup;
            classGroup = new ClassGroup()
            {
                Id = 1,
                Title = "Zvezdichka",
                AgeGroupId = 1

            };
            classGroups.Add(classGroup);

            classGroup = new ClassGroup()
            {
                Id = 2,
                Title = "Mecho Puh",
                AgeGroupId = 2

            };
            classGroups.Add(classGroup);


            classGroup = new ClassGroup()
            {
                Id = 3,
                Title = "Pinokio",
                AgeGroupId = 3

            };
            classGroups.Add(classGroup);

            classGroup = new ClassGroup()
            {
                Id = 4,
                Title = "Rusalka",
                AgeGroupId = 4

            };
            classGroups.Add(classGroup);

            classGroup = new ClassGroup()
            {
                Id = 5,
                Title = "Chaika",
                AgeGroupId = 4

            };
            classGroups.Add(classGroup);
            return classGroups.ToArray();

        }
    }
}
