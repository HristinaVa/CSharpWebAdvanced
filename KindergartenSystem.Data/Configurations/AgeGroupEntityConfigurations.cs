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
        }
    }
}
