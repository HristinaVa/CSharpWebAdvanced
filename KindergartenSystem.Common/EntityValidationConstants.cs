﻿namespace KindergartenSystem.Common
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
        public static class Child
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 30;
            public const int ImageUrlMaxLength = 2048;
            public const string DateOfBirthFormat = "dd/MM/yyyy";


        }
        public static class Teacher
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 60;
            public const int ImageUrlMaxLength = 2048;
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

        }
        public static class Image
        {
            public const int ImageUrlMaxLength = 2048;

        }
    }
}
