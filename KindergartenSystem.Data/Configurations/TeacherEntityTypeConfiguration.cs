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
    public class TeacherEntityTypeConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder
                .HasOne(t => t.ClassGroup)
                .WithMany(t => t.Teachers)
                .HasForeignKey(t => t.ClassGroupId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
