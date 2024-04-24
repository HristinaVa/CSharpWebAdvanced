using KindergartenSystem.Data;
using KindergartenSystem.Data.Models;

namespace KindergartenSystem.Services.Tests
{
    public static class DataSeed
    {
        public static ApplicationUser TeacherUser;
        public static ApplicationUser ParentUser;
        public static Teacher Teacher;
        public static Child Child;

        public static void SeedData(KindergartenDbContext context)
        {
            TeacherUser = new ApplicationUser()
            {
                Id = "df264ead-ecc2-4005-8907-f5ab23d53d20",
                UserName = "marta@user.bg",
                NormalizedUserName = "MARTA@USER.BG",
                Email = "marta@user.bg",
                NormalizedEmail = "MARTA@USER.BG",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEBZnbomv84tIsdwCKMRlUAi+RUdNWwRbUcLZzqbL66FPiPjJ7CYZ0hu+qp2CKaKQAg==",
                SecurityStamp = "CKIJ4B7MAASWW427TEMD5544JJOHRZUU",
                TwoFactorEnabled = false,
                FirstName = "Mart",
                LastName = "Mar",
                ConcurrencyStamp = "02803441-9de8-4098-b60a-5ce1d804041e"



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
                PhoneNumber = "+359000000000",
                ClassGroupId = 1,
                ImageUrl = "https://t4.ftcdn.net/jpg/04/75/00/99/360_F_475009987_zwsk4c77x3cTpcI3W1C1LU4pOSyPKaqi.jpg",
                User = TeacherUser,
                IsWorking = true,
                UserId = TeacherUser.Id,
                Name = "Mart Mar"
                
            };
            Child = new Child()
            {
                FirstName = "Yani",
                MiddleName = "Ivanov",
                LastName = "Ivanov",
                DateOfBirth = DateTime.Today,
                ImageUrl = "https://i.pinimg.com/736x/20/7c/9a/207c9a0c107ec57c0d97d5ae0bbbc851.jpg",
                ClassGroupId = 1,
                ParentId = Guid.Parse("7DD0AE27-C524-4327-AE16-BBF08677E10C"),



            };
            context.Users.Add(TeacherUser);
            context.Users.Add(ParentUser);
            context.Teachers.Add(Teacher);
            context.Children.Add(Child);
            context.SaveChanges();
        }
    }
}
