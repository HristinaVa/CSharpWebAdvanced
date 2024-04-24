using KindergartenSystem.Data.Migrations;
using KindergartenSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static KindergartenSystem.Common.GeneralApplicationConstants;

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

            builder.Property<bool>("IsWorking").ValueGeneratedOnAdd().HasColumnType("bit").HasDefaultValue(true);


            builder.HasData(GenerateTeachers());
        }
        private Teacher[] GenerateTeachers()
        {
            ICollection<Teacher> teachers = new HashSet<Teacher>();
            Teacher teacher;
            

            /// <summary>
            /// Adding AdminTeacher to the database
            /// </summary>
            
            teacher = new Teacher()
            {
                Name = "Admin Admin",
                ImageUrl = "https://t4.ftcdn.net/jpg/04/75/00/99/360_F_475009987_zwsk4c77x3cTpcI3W1C1LU4pOSyPKaqi.jpg",
                PhoneNumber = "+359000000000",
                EmailAddress = AdminEmail,
                ClassGroupId = 1,
                UserId = "bcb4f072-ecca-43c9-ab26-c060c6f264e4"

            };
            teachers.Add(teacher);
            return teachers.ToArray();
        }
    }
}

