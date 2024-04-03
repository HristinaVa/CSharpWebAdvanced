using KindergartenSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Globalization;

namespace KindergartenSystem.Data.Configurations
{
    public class ChildEntityConfiguration : IEntityTypeConfiguration<Child>
    {
        public void Configure(EntityTypeBuilder<Child> builder)
        {
            builder
            .HasOne(c => c.ClassGroup)
            .WithMany(c => c.Children)
            .HasForeignKey(c => c.ClassGroupId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(c => c.Parent)
            .WithMany(c => c.Children)
            .HasForeignKey(c => c.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(GenerateChildren());
        }
        private Child[] GenerateChildren()
        {
            ICollection<Child> children = new HashSet<Child>();
            Child child;
            child = new Child()
            {
                FirstName = "Alex",
                MiddleName = "Hristov",
                LastName = "Iliev",
                DateOfBirth = DateTime.ParseExact("02/02/2019",
                Common.EntityValidationConstants.ChildConst.DateOfBirthFormat, CultureInfo.InvariantCulture),
                ImageUrl = "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg",
                ClassGroupId = 2,
                ParentId = Guid.Parse("1AF4589C-7297-4DBD-AD7D-BB275E8820B4")
            };
            children.Add(child);
            return children.ToArray();
        }
    }
}
