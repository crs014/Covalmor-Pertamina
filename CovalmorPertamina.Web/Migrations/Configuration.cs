namespace CovalmorPertamina.Web.Migrations
{
    using CovalmorPertamina.Common.Statics;
    using CovalmorPertamina.Common.Services;
    using CovalmorPertamina.Entity.Enum;
    using CovalmorPertamina.Entity.Model;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CovalmorPertamina.Web.CovalmorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CovalmorPertamina.Web.CovalmorContext context)
        {
            List<User> users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Email = "admin@covalmor1.com",
                    Password = PasswordHash.GetHash("12345678"),
                    Name = "Administrator",
                    Role = EUserRole.Admin

                },
                new User()
                {
                    Id = 2,
                    Email = "user@covalmor1.com",
                    Password = PasswordHash.GetHash("12345678"),
                    Name = "User",
                    Role = EUserRole.User
                },
                new User()
                {
                    Id = 3,
                    Email = "ar@covalmor1.com",
                    Password = PasswordHash.GetHash("12345678"),
                    Name = "Account Receivable",
                    Role = EUserRole.AR
                },
                new User()
                {
                    Id = 4,
                    Email = "cashbank@covalmor1.com",
                    Password = PasswordHash.GetHash("12345678"),
                    Name = "Cash Bank",
                    Role = EUserRole.CashBank
                },
                new User()
                {
                    Id = 5,
                    Email = "fbs@covalmor1.com",
                    Password = PasswordHash.GetHash("12345678"),
                    Name = "Finance Business Support",
                    Role = EUserRole.FBS
                },
                new User()
                {
                    Id = 6,
                    Email = "manajemenresiko@covalmor1.com",
                    Password = PasswordHash.GetHash("12345678"),
                    Name = "Manajemen Resiko",
                    Role = EUserRole.ManagementRisk
                },
                new User()
                {
                    Id = 7,
                    Email = "komitekredit@covalmor1.com",
                    Password = PasswordHash.GetHash("12345678"),
                    Name = "Komite Kredit",
                    Role = EUserRole.KomiteCredit
                }
            };
            List<StaticValue> staticValues = new List<StaticValue>()
            {
                #region Jatuh Tempo
                new StaticValue() { Id = 1,  TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option1 },
                new StaticValue() { Id = 2, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option2 },
                new StaticValue() { Id = 3, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option3 },
                new StaticValue() { Id = 4, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option4 },
                new StaticValue() { Id = 5, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option5 },
                new StaticValue() { Id = 6, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option6 },
                new StaticValue() { Id = 7, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option7 },
                new StaticValue() { Id = 8, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option8 },
                new StaticValue() { Id = 9, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option9 },
                new StaticValue() { Id = 10, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option10 },
                new StaticValue() { Id = 11, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option12 },
                new StaticValue() { Id = 12, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option13 },
                new StaticValue() { Id = 13, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option14 },
                new StaticValue() { Id = 14, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option15 },
                new StaticValue() { Id = 15, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option16 },
                new StaticValue() { Id = 16, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option17 },
                new StaticValue() { Id = 17, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option18 },
                new StaticValue() { Id = 18, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option19 },
                new StaticValue() { Id = 19, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option20 },
                new StaticValue() { Id = 20, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option21 },
                new StaticValue() { Id = 21, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option22 },
                new StaticValue() { Id = 22, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option23 },
                new StaticValue() { Id = 23, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option24 },
                new StaticValue() { Id = 24, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option25 },
                new StaticValue() { Id = 25, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option26 },
                new StaticValue() { Id = 26, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option27 },
                new StaticValue() { Id = 27, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option28 },
                new StaticValue() { Id = 28, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option29 },
                new StaticValue() { Id = 29, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option30 },
                new StaticValue() { Id = 30, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option31 },
                new StaticValue() { Id = 31, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option32 },
                new StaticValue() { Id = 32, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option33 },
                new StaticValue() { Id = 33, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option34 },
                new StaticValue() { Id = 34, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option35 },
                new StaticValue() { Id = 35, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option36 },
                new StaticValue() { Id = 36, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option37 },
                new StaticValue() { Id = 37, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option38 },
                new StaticValue() { Id = 38, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option39 },
                new StaticValue() { Id = 39, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option40 },
                new StaticValue() { Id = 40, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option41 },
                new StaticValue() { Id = 41, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option42 },
                new StaticValue() { Id = 42, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option43 },
                new StaticValue() { Id = 43, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option44 },
                new StaticValue() { Id = 44, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option45 },
                new StaticValue() { Id = 45, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option46 },
                new StaticValue() { Id = 46, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option47 },
                new StaticValue() { Id = 47, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option48 },
                new StaticValue() { Id = 48, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option49 },
                new StaticValue() { Id = 49, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option50 },
                new StaticValue() { Id = 50, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option51 },
                new StaticValue() { Id = 51, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option52 },
                new StaticValue() { Id = 52, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option53 },
                new StaticValue() { Id = 53, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option54 },
                new StaticValue() { Id = 54, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option55 },
                new StaticValue() { Id = 55, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option56 },
                new StaticValue() { Id = 56, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option57 },
                new StaticValue() { Id = 57, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option58 },
                new StaticValue() { Id = 58, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option59 },
                new StaticValue() { Id = 59, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option60 },
                new StaticValue() { Id = 60, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option61 },
                new StaticValue() { Id = 61, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option62 },
                new StaticValue() { Id = 62, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option63 },
                new StaticValue() { Id = 63, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option64 },
                new StaticValue() { Id = 64, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option65 },
                new StaticValue() { Id = 65, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option66 },
                new StaticValue() { Id = 66, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option67 },
                new StaticValue() { Id = 67, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option68 },
                new StaticValue() { Id = 68, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option69 },
                new StaticValue() { Id = 69, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option70 },
                new StaticValue() { Id = 70, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option71 },
                new StaticValue() { Id = 71, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option72 },
                new StaticValue() { Id = 72, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option73 },
                new StaticValue() { Id = 73, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option74 },
                new StaticValue() { Id = 74, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option75 },
                new StaticValue() { Id = 75, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option76 },
                new StaticValue() { Id = 76, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option77 },
                new StaticValue() { Id = 77, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option78 },
                new StaticValue() { Id = 78, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option79 },
                new StaticValue() { Id = 79, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option80 },
                new StaticValue() { Id = 80, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option81 },
                new StaticValue() { Id = 81, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option82 },
                new StaticValue() { Id = 82, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Option83 },
                new StaticValue() { Id = 83, TypeName = ConstantValue.StaticAttributeName.JatuhTempo, TextValue = ConstantValue.JatuhTempo.Other },
                #endregion

                #region Bank
                new StaticValue() { Id = 84, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option1 },
                new StaticValue() { Id = 85, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option2 },
                new StaticValue() { Id = 86, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option3 },
                new StaticValue() { Id = 87, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option4 },
                new StaticValue() { Id = 88, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option5 },
                new StaticValue() { Id = 89, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option6 },
                new StaticValue() { Id = 90, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option7 },
                new StaticValue() { Id = 91, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option8 },
                new StaticValue() { Id = 92, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option9 },
                new StaticValue() { Id = 93, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option10 },
                new StaticValue() { Id = 94, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option11 },
                new StaticValue() { Id = 95, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option12 },
                new StaticValue() { Id = 95, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option13 },
                new StaticValue() { Id = 96, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option14 },
                new StaticValue() { Id = 97, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option15 },
                new StaticValue() { Id = 98, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option16 },
                new StaticValue() { Id = 99, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option17 },
                new StaticValue() { Id = 100, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option18 },
                new StaticValue() { Id = 101, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option19 },
                new StaticValue() { Id = 102, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option20 },
                new StaticValue() { Id = 103, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option21 },
                new StaticValue() { Id = 104, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option22 },
                new StaticValue() { Id = 105, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option23 },
                new StaticValue() { Id = 106, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option24 },
                new StaticValue() { Id = 107, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option25 },
                new StaticValue() { Id = 108, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option26 },
                new StaticValue() { Id = 109, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option27 },
                new StaticValue() { Id = 110, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option28 },
                new StaticValue() { Id = 111, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option29 },
                new StaticValue() { Id = 112, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option30 },
                new StaticValue() { Id = 113, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option31 },
                new StaticValue() { Id = 114, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option32 },
                new StaticValue() { Id = 115, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option33 },
                new StaticValue() { Id = 116, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option34 },
                new StaticValue() { Id = 117, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option35 },
                new StaticValue() { Id = 118, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option36 },
                new StaticValue() { Id = 119, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option37 },
                new StaticValue() { Id = 120, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option38 },
                new StaticValue() { Id = 121, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option39 },
                new StaticValue() { Id = 122, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option40 },
                new StaticValue() { Id = 123, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option41 },
                new StaticValue() { Id = 124, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option42 },
                new StaticValue() { Id = 125, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option43 },
                new StaticValue() { Id = 126, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option44 },
                new StaticValue() { Id = 127, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option45 },
                new StaticValue() { Id = 128, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option46 },
                new StaticValue() { Id = 129, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option47 },
                new StaticValue() { Id = 130, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option48 },
                new StaticValue() { Id = 131, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option49 },
                new StaticValue() { Id = 132, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option50 },
                new StaticValue() { Id = 133, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option51 },
                new StaticValue() { Id = 134, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option52 },
                new StaticValue() { Id = 135, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option54 },
                new StaticValue() { Id = 136, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option55 },
                new StaticValue() { Id = 137, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option56 },
                new StaticValue() { Id = 138, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option57 },
                new StaticValue() { Id = 139, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option58 },
                new StaticValue() { Id = 140, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option59 },
                new StaticValue() { Id = 141, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option60 },
                new StaticValue() { Id = 142, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option61 },
                new StaticValue() { Id = 143, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option62 },
                new StaticValue() { Id = 144, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option63 },
                new StaticValue() { Id = 145, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option64 },
                new StaticValue() { Id = 146, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option65 },
                new StaticValue() { Id = 147, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option66 },
                new StaticValue() { Id = 148, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option67 },
                new StaticValue() { Id = 149, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option68 },
                new StaticValue() { Id = 150, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option69 },
                new StaticValue() { Id = 151, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option70 },
                new StaticValue() { Id = 152, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option71 },
                new StaticValue() { Id = 153, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option72 },
                new StaticValue() { Id = 154, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option73 },
                new StaticValue() { Id = 155, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option74 },
                new StaticValue() { Id = 156, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option75 },
                new StaticValue() { Id = 157, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option76 },
                new StaticValue() { Id = 158, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option77 },
                new StaticValue() { Id = 159, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option78 },
                new StaticValue() { Id = 160, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option79 },
                new StaticValue() { Id = 161, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option80 },
                new StaticValue() { Id = 162, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option81 },
                new StaticValue() { Id = 163, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option82 },
                new StaticValue() { Id = 164, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option83 },
                new StaticValue() { Id = 165, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option84 },
                new StaticValue() { Id = 166, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option85 },
                new StaticValue() { Id = 167, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option86 },
                new StaticValue() { Id = 168, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option87 },
                new StaticValue() { Id = 169, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option88 },
                new StaticValue() { Id = 170, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option89 },
                new StaticValue() { Id = 171, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option90 },
                new StaticValue() { Id = 172, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option91 },
                new StaticValue() { Id = 173, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option92 },
                new StaticValue() { Id = 174, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option93 },
                new StaticValue() { Id = 175, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option94 },
                new StaticValue() { Id = 176, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option95 },
                new StaticValue() { Id = 177, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option96 },
                new StaticValue() { Id = 178, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option97 },
                new StaticValue() { Id = 179, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option98 },
                new StaticValue() { Id = 180, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option99 },
                new StaticValue() { Id = 181, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option100 },
                new StaticValue() { Id = 182, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option101 },
                new StaticValue() { Id = 183, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option102 },
                new StaticValue() { Id = 184, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option103 },
                new StaticValue() { Id = 185, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option104 },
                new StaticValue() { Id = 186, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option105 },
                new StaticValue() { Id = 187, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option106 },
                new StaticValue() { Id = 188, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option107 },
                new StaticValue() { Id = 189, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option108 },
                new StaticValue() { Id = 190, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option109 },
                new StaticValue() { Id = 191, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option110 },
                new StaticValue() { Id = 192, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option111 },
                new StaticValue() { Id = 193, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option112 },
                new StaticValue() { Id = 194, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option113 },
                new StaticValue() { Id = 195, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option114 },
                new StaticValue() { Id = 196, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option115 },
                new StaticValue() { Id = 197, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option116 },
                new StaticValue() { Id = 198, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option117 },
                new StaticValue() { Id = 199, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option118 },
                new StaticValue() { Id = 200, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option119 },
                new StaticValue() { Id = 201, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option120 },
                new StaticValue() { Id = 202, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option121 },
                new StaticValue() { Id = 203, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option122 },
                new StaticValue() { Id = 204, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option123 },
                new StaticValue() { Id = 205, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Option124 },
                new StaticValue() { Id = 206, TypeName = ConstantValue.StaticAttributeName.Bank, TextValue = ConstantValue.Bank.Other },
                #endregion

                #region Bentuk Jaminan
                new StaticValue() { Id = 207, TypeName = ConstantValue.StaticAttributeName.BentukJaminan, TextValue = ConstantValue.BentukJaminan.Option1 },
                new StaticValue() { Id = 208, TypeName = ConstantValue.StaticAttributeName.BentukJaminan, TextValue = ConstantValue.BentukJaminan.Option2 },
                new StaticValue() { Id = 209, TypeName = ConstantValue.StaticAttributeName.BentukJaminan, TextValue = ConstantValue.BentukJaminan.Option3 },
                new StaticValue() { Id = 210, TypeName = ConstantValue.StaticAttributeName.BentukJaminan, TextValue = ConstantValue.BentukJaminan.Option4 },
                new StaticValue() { Id = 211, TypeName = ConstantValue.StaticAttributeName.BentukJaminan, TextValue = ConstantValue.BentukJaminan.Other },
                #endregion

                #region Syarat Penyerahan
                new StaticValue() { Id = 212, TypeName = ConstantValue.StaticAttributeName.SyaratPenyerahan, TextValue = ConstantValue.SyaratPenyerahan.Option1 },
                new StaticValue() { Id = 213, TypeName = ConstantValue.StaticAttributeName.SyaratPenyerahan, TextValue = ConstantValue.SyaratPenyerahan.Option2 },
                new StaticValue() { Id = 214, TypeName = ConstantValue.StaticAttributeName.SyaratPenyerahan, TextValue = ConstantValue.SyaratPenyerahan.Other },
                #endregion

                #region Periode Penagihan
                new StaticValue() { Id = 215,  TypeName = ConstantValue.StaticAttributeName.PeriodePenagihan, TextValue = ConstantValue.PeriodePenagihan.Option1 },
                new StaticValue() { Id = 216, TypeName = ConstantValue.StaticAttributeName.PeriodePenagihan, TextValue = ConstantValue.PeriodePenagihan.Option2 },
                new StaticValue() { Id = 217, TypeName = ConstantValue.StaticAttributeName.PeriodePenagihan, TextValue = ConstantValue.PeriodePenagihan.Option3 },
                new StaticValue() { Id = 218, TypeName = ConstantValue.StaticAttributeName.PeriodePenagihan, TextValue = ConstantValue.PeriodePenagihan.Option4 },
                new StaticValue() { Id = 219, TypeName = ConstantValue.StaticAttributeName.PeriodePenagihan, TextValue = ConstantValue.PeriodePenagihan.Option5 },
                #endregion

                #region Periode Volume
                new StaticValue() { Id = 220, TypeName = ConstantValue.StaticAttributeName.PeriodeVolume, TextValue = ConstantValue.PeriodeVolume.Option1 },
                new StaticValue() { Id = 221, TypeName = ConstantValue.StaticAttributeName.PeriodeVolume, TextValue = ConstantValue.PeriodeVolume.Option2 },
                new StaticValue() { Id = 222, TypeName = ConstantValue.StaticAttributeName.PeriodeVolume, TextValue = ConstantValue.PeriodeVolume.Option3 },
                new StaticValue() { Id = 223, TypeName = ConstantValue.StaticAttributeName.PeriodeVolume, TextValue = ConstantValue.PeriodeVolume.Option4 },
                new StaticValue() { Id = 224, TypeName = ConstantValue.StaticAttributeName.PeriodeVolume, TextValue = ConstantValue.PeriodeVolume.Option5 },
                new StaticValue() { Id = 225, TypeName = ConstantValue.StaticAttributeName.PeriodeVolume, TextValue = ConstantValue.PeriodeVolume.Option6 },
                #endregion

                #region UOM
                new StaticValue() { Id = 226, TypeName = ConstantValue.StaticAttributeName.UOM, TextValue = ConstantValue.UOM.Option1 },
                new StaticValue() { Id = 227, TypeName = ConstantValue.StaticAttributeName.UOM, TextValue = ConstantValue.UOM.Option2 },
                new StaticValue() { Id = 228, TypeName = ConstantValue.StaticAttributeName.UOM, TextValue = ConstantValue.UOM.Option3 },
                new StaticValue() { Id = 229, TypeName = ConstantValue.StaticAttributeName.UOM, TextValue = ConstantValue.UOM.Option4 },
                new StaticValue() { Id = 230, TypeName = ConstantValue.StaticAttributeName.UOM, TextValue = ConstantValue.UOM.Option5 },
                #endregion

                #region Jenis Industri
                new StaticValue() { Id = 231, TypeName = ConstantValue.StaticAttributeName.JenisIndustri, TextValue = ConstantValue.JenisIndustri.Option1 },
                new StaticValue() { Id = 232, TypeName = ConstantValue.StaticAttributeName.JenisIndustri, TextValue = ConstantValue.JenisIndustri.Option2 },
                new StaticValue() { Id = 233, TypeName = ConstantValue.StaticAttributeName.JenisIndustri, TextValue = ConstantValue.JenisIndustri.Option3 },
                new StaticValue() { Id = 234, TypeName = ConstantValue.StaticAttributeName.JenisIndustri, TextValue = ConstantValue.JenisIndustri.Option4 },
                new StaticValue() { Id = 235, TypeName = ConstantValue.StaticAttributeName.JenisIndustri, TextValue = ConstantValue.JenisIndustri.Option5 },
                new StaticValue() { Id = 236, TypeName = ConstantValue.StaticAttributeName.JenisIndustri, TextValue = ConstantValue.JenisIndustri.Option6 },
                new StaticValue() { Id = 237, TypeName = ConstantValue.StaticAttributeName.JenisIndustri, TextValue = ConstantValue.JenisIndustri.Option7 },
                #endregion

                #region Rata Rata Keterlambatan
                new StaticValue() { Id = 238, TypeName = ConstantValue.StaticAttributeName.RataKeterlambatan, TextValue = ConstantValue.RataKeterlambatan.Option1, ColumnScore = 4 },
                new StaticValue() { Id = 239, TypeName = ConstantValue.StaticAttributeName.RataKeterlambatan, TextValue = ConstantValue.RataKeterlambatan.Option2, ColumnScore = 4 },
                new StaticValue() { Id = 240, TypeName = ConstantValue.StaticAttributeName.RataKeterlambatan, TextValue = ConstantValue.RataKeterlambatan.Option3, ColumnScore = 4 },
                new StaticValue() { Id = 241, TypeName = ConstantValue.StaticAttributeName.RataKeterlambatan, TextValue = ConstantValue.RataKeterlambatan.Option4, ColumnScore = 4 },
                new StaticValue() { Id = 242, TypeName = ConstantValue.StaticAttributeName.RataKeterlambatan, TextValue = ConstantValue.RataKeterlambatan.Option5, ColumnScore = 4 },
                #endregion

                #region Riwayat Restrukturisasi
                new StaticValue() { Id = 243, TypeName = ConstantValue.StaticAttributeName.RiwayatRestrukturisasi, TextValue = ConstantValue.RiwayatRestrukturisasi.Option1, ColumnScore = 3 },
                new StaticValue() { Id = 244, TypeName = ConstantValue.StaticAttributeName.RiwayatRestrukturisasi, TextValue = ConstantValue.RiwayatRestrukturisasi.Option2, ColumnScore = 3 },
                new StaticValue() { Id = 245, TypeName = ConstantValue.StaticAttributeName.RiwayatRestrukturisasi, TextValue = ConstantValue.RiwayatRestrukturisasi.Option3, ColumnScore = 3 },
                #endregion

                #region Fasilitas Kredit
                new StaticValue() { Id = 246, TypeName = ConstantValue.StaticAttributeName.FasilitasKredit, TextValue = ConstantValue.FasilitasKredit.Option1, ColumnScore = 1 },
                new StaticValue() { Id = 247, TypeName = ConstantValue.StaticAttributeName.FasilitasKredit, TextValue = ConstantValue.FasilitasKredit.Option2, ColumnScore = 1 },

                #endregion

                #region Lama BekerjaSama
                new StaticValue() { Id = 248, TypeName = ConstantValue.StaticAttributeName.LamaBekerjaSama, TextValue = ConstantValue.LamaBekerjaSama.Option1, ColumnScore = 3 },
                new StaticValue() { Id = 249, TypeName = ConstantValue.StaticAttributeName.LamaBekerjaSama, TextValue = ConstantValue.LamaBekerjaSama.Option2, ColumnScore = 3 },
                new StaticValue() { Id = 250, TypeName = ConstantValue.StaticAttributeName.LamaBekerjaSama, TextValue = ConstantValue.LamaBekerjaSama.Option3, ColumnScore = 3 },
                new StaticValue() { Id = 251, TypeName = ConstantValue.StaticAttributeName.LamaBekerjaSama, TextValue = ConstantValue.LamaBekerjaSama.Option4, ColumnScore = 3 },
                #endregion

                #region Vendor Pemasok
                new StaticValue() { Id = 252, TypeName = ConstantValue.StaticAttributeName.VendorPemasok, TextValue = ConstantValue.VendorPemasok.Option1, ColumnScore = 2 },
                new StaticValue() { Id = 253, TypeName = ConstantValue.StaticAttributeName.VendorPemasok, TextValue = ConstantValue.VendorPemasok.Option2, ColumnScore = 2 },
                new StaticValue() { Id = 254, TypeName = ConstantValue.StaticAttributeName.VendorPemasok, TextValue = ConstantValue.VendorPemasok.Option3, ColumnScore = 2 },
                #endregion

                #region Posisi Tawar Pertamina
                new StaticValue() { Id = 255, TypeName = ConstantValue.StaticAttributeName.PosisiTawarPertamina, TextValue = ConstantValue.PosisiTawarPertamina.Option1, ColumnScore = 1 },
                new StaticValue() { Id = 256, TypeName = ConstantValue.StaticAttributeName.PosisiTawarPertamina, TextValue = ConstantValue.PosisiTawarPertamina.Option2, ColumnScore = 1 },
                #endregion

                #region Badan Usaha 
                new StaticValue() { Id = 257, TypeName = ConstantValue.StaticAttributeName.BadanUsaha, TextValue = ConstantValue.BadanUsaha.Option1, ColumnScore = 3 },
                new StaticValue() { Id = 258, TypeName = ConstantValue.StaticAttributeName.BadanUsaha, TextValue = ConstantValue.BadanUsaha.Option2, ColumnScore = 3 },
                new StaticValue() { Id = 259, TypeName = ConstantValue.StaticAttributeName.BadanUsaha, TextValue = ConstantValue.BadanUsaha.Option3, ColumnScore = 3 },
                new StaticValue() { Id = 260, TypeName = ConstantValue.StaticAttributeName.BadanUsaha, TextValue = ConstantValue.BadanUsaha.Option4, ColumnScore = 3 },
                #endregion

                #region Afiliasi
                new StaticValue() { Id = 261, TypeName = ConstantValue.StaticAttributeName.Afiliasi, TextValue = ConstantValue.Afiliasi.Option1, ColumnScore = 2 },
                new StaticValue() { Id = 262, TypeName = ConstantValue.StaticAttributeName.Afiliasi, TextValue = ConstantValue.Afiliasi.Option2, ColumnScore = 2 },
                new StaticValue() { Id = 263, TypeName = ConstantValue.StaticAttributeName.Afiliasi, TextValue = ConstantValue.Afiliasi.Option3, ColumnScore = 2 },
                #endregion

                #region Kondisi Industri
                new StaticValue() { Id = 264, TypeName = ConstantValue.StaticAttributeName.KondisiIndustri, TextValue = ConstantValue.KondisiIndustri.Option1, ColumnScore = 2 },
                new StaticValue() { Id = 265, TypeName = ConstantValue.StaticAttributeName.KondisiIndustri, TextValue = ConstantValue.KondisiIndustri.Option2, ColumnScore = 2 },
                new StaticValue() { Id = 266, TypeName = ConstantValue.StaticAttributeName.KondisiIndustri, TextValue = ConstantValue.KondisiIndustri.Option3, ColumnScore = 2 },
                #endregion

                #region Opini Audit
                new StaticValue() { Id = 267, TypeName = ConstantValue.StaticAttributeName.OpiniAudit, TextValue = ConstantValue.OpiniAudit.Option1, ColumnScore = 2 },
                new StaticValue() { Id = 268, TypeName = ConstantValue.StaticAttributeName.OpiniAudit, TextValue = ConstantValue.OpiniAudit.Option2, ColumnScore = 2  },
                new StaticValue() { Id = 269, TypeName = ConstantValue.StaticAttributeName.OpiniAudit, TextValue = ConstantValue.OpiniAudit.Option3, ColumnScore = 2  },
                #endregion

                #region Terdaftar Audit KAP
                new StaticValue() { Id = 270, TypeName = ConstantValue.StaticAttributeName.TerdaftarAuditKAP, TextValue = ConstantValue.TerdaftarAuditKAP.Option1, ColumnScore = 1 },
                new StaticValue() { Id = 271, TypeName = ConstantValue.StaticAttributeName.TerdaftarAuditKAP, TextValue = ConstantValue.TerdaftarAuditKAP.Option2, ColumnScore = 1 },
                #endregion

                #region Mata Uang
                new StaticValue() { Id = 272, TypeName = ConstantValue.StaticAttributeName.MataUang, TextValue = ConstantValue.MataUang.Option1 },
                new StaticValue() { Id = 273, TypeName = ConstantValue.StaticAttributeName.MataUang, TextValue = ConstantValue.MataUang.Option2 },
                #endregion

                #region Masa Perkiraan Nilai Transaksi
                new StaticValue() { Id = 274, TypeName = ConstantValue.StaticAttributeName.MasaPerkiraanNilaiTransaksi, TextValue = ConstantValue.MasaPerkiraanNilaiTransaksi.Option1 },
                new StaticValue() { Id = 275, TypeName = ConstantValue.StaticAttributeName.MasaPerkiraanNilaiTransaksi, TextValue = ConstantValue.MasaPerkiraanNilaiTransaksi.Option2 },
                new StaticValue() { Id = 276, TypeName = ConstantValue.StaticAttributeName.MasaPerkiraanNilaiTransaksi, TextValue = ConstantValue.MasaPerkiraanNilaiTransaksi.Option3 },
                new StaticValue() { Id = 277, TypeName = ConstantValue.StaticAttributeName.MasaPerkiraanNilaiTransaksi, TextValue = ConstantValue.MasaPerkiraanNilaiTransaksi.Option4 }
                #endregion
            };

            users.ForEach(user => context.Users.AddOrUpdate(p => p.Id, user));
            staticValues.ForEach(staticValue => context.StaticValues.AddOrUpdate(p => p.Id, staticValue));
        }
    }
}
