using KindergartenSystem.Data;
using KindergartenSystem.Data.Models;

namespace KindergartenSystem.Services.Tests
{
    public static class DataSeed
    {
        public static ApplicationUser TeacherUser;
        public static ApplicationUser ParentUser;
        public static Teacher Teacher;

        public static void SeedData(KindergartenDbContext context)
        {
            TeacherUser = new ApplicationUser()
            {
                UserName = "ivanova.22@teacher.com",
                NormalizedUserName = "IVANOVA.22@TEACHER.COM",
                Email = "ivanova.22@teacher.com",
                NormalizedEmail = "IVANOVA.22@TEACHER.COM",
                EmailConfirmed = false,
                PasswordHash = "e150a1ec81e8e93e1eae2c3a77e66ec6dbd6a3b460f89c1d08aecf422ee401a0",
                SecurityStamp = "c3cdc956-7b1e-4c75-bf5d-1a383f696ffa",
                TwoFactorEnabled = false,
                FirstName = "Silviya",
                LastName = "Ivanova",
                ConcurrencyStamp = "50029594-a854-49d3-ac11-e725009b9326"



            };
            ParentUser = new ApplicationUser()
            {
                UserName = "hristina_87@mail.bg",
                NormalizedUserName = "HRISTINA_87@MAIL.BG",
                Email = "hristina_87@mail.bg",
                NormalizedEmail = "HRISTINA_87@MAIL.BG",
                EmailConfirmed = false,
                PasswordHash = "2dc0269fa54d269a87536810ec453cb095b4b92f45e63826a21dff1c2e76f169",
                SecurityStamp = "6d1d4dab-760a-436b-a98f-1b59b8eb5faa",
                TwoFactorEnabled = false,
                FirstName = "Hristina",
                LastName = "Ivanova",
                ConcurrencyStamp = "63c5de55-33e1-4309-a8eb-82b5ffe69e88\r\n"
            };
            Teacher = new Teacher()
            {
                PhoneNumber = "+359000112233",
                ClassGroupId = 2,
                ImageUrl = "https://st.depositphotos.com/1758000/2947/v/450/depositphotos_29477577-stock-illustration-eyewear-glasses-teacher-touching-chin.jpg",
                User = TeacherUser
            };
            context.Add(TeacherUser);
            context.Add(ParentUser);
            context.Add(Teacher);
            context.SaveChanges();
        }
    }
}
