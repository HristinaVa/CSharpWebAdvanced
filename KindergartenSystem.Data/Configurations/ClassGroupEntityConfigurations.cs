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
        }
    }
}
