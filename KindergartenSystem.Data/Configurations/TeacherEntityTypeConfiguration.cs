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
            
            builder.HasData(GenerateTeachers());
        }
        private Teacher[] GenerateTeachers()
        {
            ICollection<Teacher> teachers = new HashSet<Teacher>();
            Teacher teacher;
            teacher = new Teacher()
            {
                Name = "Silviq Ivanova",
                ImageUrl = "https://st.depositphotos.com/1758000/2947/v/450/depositphotos_29477577-stock-illustration-eyewear-glasses-teacher-touching-chin.jpg",
                PhoneNumber = "+359789000000",
                EmailAddress = "ivanova.22@teacher.com",
                ClassGroupId = 2,
                UserId = "4b72b514-00e0-4754-ab43-4c53199afbb8"

            };
            teachers.Add(teacher);
            return teachers.ToArray();
} } }
