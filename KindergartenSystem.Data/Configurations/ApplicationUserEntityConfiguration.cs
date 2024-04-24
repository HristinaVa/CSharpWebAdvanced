using KindergartenSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static KindergartenSystem.Common.GeneralApplicationConstants;
namespace KindergartenSystem.Data.Configurations
{
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.FirstName).HasDefaultValue("...");
            builder.Property(x => x.LastName).HasDefaultValue("...");

            builder.HasData(GenerateUsers());


        }
        private ApplicationUser[] GenerateUsers()
        {
            ICollection<ApplicationUser> users = new HashSet<ApplicationUser>();
            ApplicationUser user;
            user = new ApplicationUser()
            {
                UserName = "username@user.com",
                NormalizedUserName = "USERNAME@USER.COM",
                Email = "username@user.com",
                NormalizedEmail = "USERNAME@USER.COM",
                EmailConfirmed = false,
                PasswordHash = "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92",
                SecurityStamp = "C3CDC956-7B1E-4C75-BF5D-1A383F696FFC",
                TwoFactorEnabled = false,
                FirstName = "Katya",
                LastName = "Genova",
                ConcurrencyStamp = "50029594-a854-49d3-ac11-e725009b9323"


            };
            users.Add(user);
            user = new ApplicationUser()
            {
                Id = "bcb4f072-ecca-43c9-ab26-c060c6f364e3",
                UserName = "userparent@user.com",
                NormalizedUserName = "USERPARENT@USER.COM",
                Email = "userparent@user.com",
                NormalizedEmail = "USERPARENT@USER.COM",
                EmailConfirmed = false,
                PasswordHash = "E150A1EC81E8E93E1EAE2C3A77E66EC6DBD6A3B460F89C1D08AECF422EE401A0",
                SecurityStamp = "C3CDC956-7B1E-4C75-BF5D-1A383F696FFA",
                TwoFactorEnabled = false,
                FirstName = "Iva",
                LastName = "Ilieva",
                ConcurrencyStamp = "50029594-a854-49d3-ac11-e725009b9326"


            };
            users.Add(user);
            user = new ApplicationUser()
            {
                Id = "bcb4f072-ecca-43c9-ab26-c060c6f264e4",
                UserName = AdminEmail,
                NormalizedUserName = "ADMIN@ADMIN.BG",
                Email = AdminEmail,
                NormalizedEmail = "ADMIN@ADMIN.BG",
                EmailConfirmed = false,
                PasswordHash = "6F741B93409297B6B3BE618073B5F5899793CB18DDB45274FE6A636B1C62393A",
                SecurityStamp = "C3CDC956-7B1E-4C75-BF5D-1A383F696FFB",
                TwoFactorEnabled = false,
                FirstName = "Admin",
                LastName = "Admin",
                ConcurrencyStamp = "50029594-a854-49d3-ac11-e725009b9327",
                LockoutEnabled= true
                


            };
            users.Add(user);
            return users.ToArray();
             }
        



        }



    }


