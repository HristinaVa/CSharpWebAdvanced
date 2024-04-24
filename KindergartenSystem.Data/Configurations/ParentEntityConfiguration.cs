using KindergartenSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KindergartenSystem.Data.Configurations
{
    public class ParentEntityConfiguration : IEntityTypeConfiguration<Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            builder.HasData(GenerateParent());
        }
        private Parent[] GenerateParent()
        {
            ICollection<Parent> parents = new HashSet<Parent>();
            Parent parent;

            parent = new Parent()
            {
                Id = Guid.Parse("3CBC521E-07D7-40E5-9D16-655769D51DFF"),
                Status = Models.Enums.ParentStatus.Approved,
                UserId = "bcb4f072-ecca-43c9-ab26-c060c6f364e3",              
                Name = "Iva Ilieva",
                PhoneNumber = "+359878888881",
                Address = "ul.Morska 12",
               EmailAddress = "userparent@user.com"
               
            };

            parents.Add(parent);
            return parents.ToArray();
        }
    }
}
