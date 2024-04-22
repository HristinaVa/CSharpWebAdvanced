namespace KindergartenSystem.Common
{
    public static class EntityValidationConstants
    {
        public static class Kindergarten
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 50;
            public const int AddressMaxLength = 120;
            public const int AddressMinLength = 10;
            public const int PrincipalNameMaxLength = 120;
            public const int PrincipalNameMinLength = 10;
            public const int PhoneNumberMaxLength = 13;
            public const int PhoneNumberMinLength = 9;
            public const int EmailAddressMaxLength = 256;


        }
        public static class AgeGroup
        {
            public const int MinNumber = 1;
            public const int MaxNumber = 4;
        }
        public static class ClassGroup
        {
            public const int TitleMinLength = 2;
            public const int TitleMaxLength = 30;
        }
        public static class ChildConst
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 30;
            public const int MiddleNameMinLength = 2;
            public const int MiddleNameMaxLength = 30;
            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 30;
            public const int ImageUrlMaxLength = 2048;
            public const string DateOfBirthFormat = "dd/MM/yyyy";


        }
        public static class Teacher
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 60;
            public const int ImageUrlMaxLength = 2048;
            public const int ImageUrlMinLength = 2;
            public const int PhoneNumberMaxLength = 13;
            public const int PhoneNumberMinLength = 9;

        }
        public static class Parent
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 60;
            public const int AddressMaxLength = 120;
            public const int AddressMinLength = 5;
            public const int PhoneNumberMaxLength = 13;
            public const int PhoneNumberMinLength = 9;
            public const int EmailAddressMaxLength = 256;
            public const int EmailAddressMinLength = 5;

        }
        public static class Image
        {
            public const int ImageUrlMaxLength = 2048;

        }
        public static class ApplicationUser
        { 
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 12;
            public const int LastNameMaxLength = 15;
            public const int LastNameMinLength = 1;
            public const int PasswordMaxLength = 100;
            public const int PasswordMinLength = 6;
        }
    }
}
