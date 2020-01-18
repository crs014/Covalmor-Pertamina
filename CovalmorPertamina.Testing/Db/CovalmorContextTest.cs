using CovalmorPertamina.Common.Statics;
using CovalmorPertamina.Entity;
using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Testing.Db.Set;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CovalmorPertamina.Testing.Db
{
    public class CovalmorContextTest : IDBCovalmor
    {
        public CovalmorContextTest()
        {
            Users = new TestUserDbSet();
            Customers = new TestCustomerDbSet();
            Products = new TestProductDbSet();
            Signatures = new TestSignatureDbSet();
            CreditApprovals = new TestCreditApprovalDbSet();
            TrCaActionNotes = new TestTrCaActionNoteDbSet();
            TrCaProducts = new TestTrCaProductDbSet();
            TrCaNotes = new TestTrCaNoteDbSet();
            LoadDummyData();
        }

        public void LoadDummyData()
        {
            #region user dummy data
            Users.Add(new User()
            {
                Id = 1,
                Name = "Admin",
                Email = "admin@covalmor1.com",
                Jabatan = "Komisaris",
                Password = PasswordHash.GetHash("12345678"),
                Role = EUserRole.Admin
            });
            Users.Add(new User()
            {
                Id = 2,
                Name = "AR",
                Email = "ar@covalmor1.com",
                Jabatan = "Management Resiko",
                Password = PasswordHash.GetHash("12345678"),
                Role = EUserRole.AR
            });
            Users.Add(new User()
            {
                Id = 3,
                Name = "User",
                Email = "user@covalmor1.com",
                Jabatan = "Karyawan",
                Password = PasswordHash.GetHash("12345678"),
                Role = EUserRole.User
            });
            Users.Add(new User()
            {
                Id = 4,
                Name = "FBS",
                Email = "fbs@covalmor1.com",
                Jabatan = "Keuangan",
                Password = PasswordHash.GetHash("12345678"),
                Role = EUserRole.FBS
            });
            #endregion

            #region customer dummy data
            Customers.Add(new Customer() 
            {
                Id = 1,
                CustomerNo = "1236969",
                Name = "PT Kera Sakti",
                Email = "kerasakti@mail.com",
                Address = "Gunung kayangan",
                NPWP = "01010169"
            });
            Customers.Add(new Customer()
            {
                Id = 2,
                CustomerNo = "4616111",
                Name = "Cv Kamehameha Batam",
                Email = "kamehamehabatam@mail.com",
                Address = "Pulau roshi",
                NPWP = "222333444"
            });
            Customers.Add(new Customer()
            {
                Id = 3,
                CustomerNo = "3456789",
                Name = "PT Santai Menyantai",
                Email = "santai@mail.com",
                Address = "Jalan malas",
                NPWP = "55667788"
            });
            Customers.Add(new Customer()
            {
                Id = 4,
                CustomerNo = "3456789",
                Name = "PT Ninja Gadungan",
                Email = "ninja@mail.com",
                Address = "Konohahaha",
                NPWP = "777888999"
            });
            #endregion

            #region product dummy data
            Products.Add(new Product()
            {
                Id = 1,
                MaterialNo = "001",
                MaterialName = "Premium",
                MaterialGroup = "001"
            });
            Products.Add(new Product()
            {
                Id = 2,
                MaterialNo = "002",
                MaterialName = "Pertalite",
                MaterialGroup = "002"
            });
            Products.Add(new Product()
            {
                Id = 3,
                MaterialNo = "003",
                MaterialName = "Solar",
                MaterialGroup = "003"
            });
            Products.Add(new Product()
            {
                Id = 4,
                MaterialNo = "004",
                MaterialName = "Pertamax",
                MaterialGroup = "004"
            });
            #endregion

            #region signature dummy data
            Signatures.Add(new Signature()
            {
                Id = 1,
                Name1 = "Basuki cahaya purnama",
                Name2 = "Eric Thoir",
                Position1 = "Komisaris Utama",
                Position2 = "Menteri BUMN",
                DocumentType = "CA"
            });
            Signatures.Add(new Signature()
            {
                Id = 2,
                Name1 = "Goku",
                Name2 = "Vegeta",
                Position1 = "Earth Saiyan",
                Position2 = "Prince Saiyan",
                DocumentType = "CA"
            });
            Signatures.Add(new Signature()
            {
                Id = 3,
                Name1 = "Ramen",
                Name2 = "Burger",
                Position1 = "Japanese Noodle",
                Position2 = "USA Sandwich",
                DocumentType = "CA"
            });
            Signatures.Add(new Signature()
            {
                Id = 4,
                Name1 = "PUBG",
                Name2 = "Mobile Legend",
                Position1 = "Battle Royale",
                Position2 = "Moba",
                DocumentType = "CA"
            });
            #endregion

            #region credit approval dummy data
            CreditApprovals.Add(new CreditApproval()
            {
                Id = 1,
                TicketNumber = "44667788",
                MailNumber = "1122334455",
                CustomerId = 3,
                TempoStart = Convert.ToDateTime("01/12/2019"),
                TempoEnd = Convert.ToDateTime("05/05/2020"),
                LongTempo = "Perbulan 1 kali",
                Volume = "2 Liter",
                Units = "Per Kg",
                PeriodeVolume = "Perbulan Volume",
                SubmissionPeriod = "Kapan Saja",
                TransactionValue = "Rp 2.000.000",
                CreditLimit = "Rp 2.500.000",
                Payment = "Bank Indonesia",
                Guarantee = "BPOM",
                Status = EStatusCredit.DraftUser,
                FlagRead = true,
                FlagFine = true,
                CreatedBy = 1,
                Currency = "Rp",
                TransactionValueEstimatedPeriod = "Perbulan Pengeluaran",
                TrCaActionNote = new List<TrCaActionNote>(),
                TrCaProducts = new List<TrCaProduct>(),
                TrCaNotes = new List<TrCaNote>(),
                CaCustomerDetails = new List<CaCustomerDetail>(),
                QuantitativeAspects = new List<QuantitativeAspect>(),
                CreditScorings = new List<CreditScoring>(),
                User = new User()
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "admin@covalmor1.com",
                    Jabatan = "Komisaris",
                    Password = PasswordHash.GetHash("12345678"),
                    Role = EUserRole.Admin
                }
            });
            CreditApprovals.Add(new CreditApproval()
            {
                Id = 2,
                TicketNumber = "44667788",
                MailNumber = "1122334455",
                CustomerId = 2,
                TempoStart = Convert.ToDateTime("01/12/2019"),
                TempoEnd = Convert.ToDateTime("05/05/2020"),
                LongTempo = "Perbulan 1 kali",
                Volume = "2 Liter",
                Units = "Per Kg",
                PeriodeVolume = "Perbulan Volume",
                SubmissionPeriod = "Kapan Saja",
                TransactionValue = "Rp 2.000.000",
                CreditLimit = "Rp 2.500.000",
                Payment = "Bank Indonesia",
                Guarantee = "BPOM",
                Status = EStatusCredit.AR,
                FlagRead = true,
                FlagFine = true,
                CreatedBy = 1,
                Currency = "Rp",
                TransactionValueEstimatedPeriod = "Perbulan Pengeluaran",
                TrCaActionNote = new List<TrCaActionNote>(),
                TrCaProducts = new List<TrCaProduct>(),
                TrCaNotes = new List<TrCaNote>(),
                CaCustomerDetails = new List<CaCustomerDetail>(),
                QuantitativeAspects = new List<QuantitativeAspect>(),
                CreditScorings = new List<CreditScoring>(),
                User = new User()
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "admin@covalmor1.com",
                    Jabatan = "Komisaris",
                    Password = PasswordHash.GetHash("12345678"),
                    Role = EUserRole.Admin
                }
            });
            CreditApprovals.Add(new CreditApproval()
            {
                Id = 3,
                TicketNumber = "44667788",
                MailNumber = "1122334455",
                CustomerId = 1,
                TempoStart = Convert.ToDateTime("01/12/2019"),
                TempoEnd = Convert.ToDateTime("05/05/2020"),
                LongTempo = "Perbulan 1 kali",
                Volume = "2 Liter",
                Units = "Per Kg",
                PeriodeVolume = "Perbulan Volume",
                SubmissionPeriod = "Kapan Saja",
                TransactionValue = "Rp 2.000.000",
                CreditLimit = "Rp 2.500.000",
                Payment = "Bank Indonesia",
                Guarantee = "BPOM",
                Status = EStatusCredit.CashBank,
                FlagRead = true,
                FlagFine = true,
                CreatedBy = 1,
                Currency = "Rp",
                TransactionValueEstimatedPeriod = "Perbulan Pengeluaran",
                TrCaActionNote = new List<TrCaActionNote>(),
                TrCaProducts = new List<TrCaProduct>(),
                TrCaNotes = new List<TrCaNote>(),
                CaCustomerDetails = new List<CaCustomerDetail>(),
                QuantitativeAspects = new List<QuantitativeAspect>(),
                CreditScorings = new List<CreditScoring>(),
                User = new User()
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "admin@covalmor1.com",
                    Jabatan = "Komisaris",
                    Password = PasswordHash.GetHash("12345678"),
                    Role = EUserRole.Admin
                }
            });
            CreditApprovals.Add(new CreditApproval()
            {
                Id = 4,
                TicketNumber = "44667788",
                MailNumber = "1122334455",
                CustomerId = 4,
                TempoStart = Convert.ToDateTime("01/12/2019"),
                TempoEnd = Convert.ToDateTime("05/05/2020"),
                LongTempo = "Perbulan 1 kali",
                Volume = "2 Liter",
                Units = "Per Kg",
                PeriodeVolume = "Perbulan Volume",
                SubmissionPeriod = "Kapan Saja",
                TransactionValue = "Rp 2.000.000",
                CreditLimit = "Rp 2.500.000",
                Payment = "Bank Indonesia",
                Guarantee = "BPOM",
                Status = EStatusCredit.FBS,
                FlagRead = true,
                FlagFine = true,
                CreatedBy = 1,
                Currency = "Rp",
                TransactionValueEstimatedPeriod = "Perbulan Pengeluaran",
                TrCaActionNote = new List<TrCaActionNote>(),
                TrCaProducts = new List<TrCaProduct>(),
                TrCaNotes = new List<TrCaNote>(),
                CaCustomerDetails = new List<CaCustomerDetail>(),
                QuantitativeAspects = new List<QuantitativeAspect>(),
                CreditScorings = new List<CreditScoring>(),
                User = new User()
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "admin@covalmor1.com",
                    Jabatan = "Komisaris",
                    Password = PasswordHash.GetHash("12345678"),
                    Role = EUserRole.Admin
                }
            });
            CreditApprovals.Add(new CreditApproval()
            {
                Id = 5,
                TicketNumber = "44667788",
                MailNumber = "1122334455",
                CustomerId = 2,
                TempoStart = Convert.ToDateTime("01/12/2019"),
                TempoEnd = Convert.ToDateTime("05/05/2020"),
                LongTempo = "Perbulan 1 kali",
                Volume = "2 Liter",
                Units = "Per Kg",
                PeriodeVolume = "Perbulan Volume",
                SubmissionPeriod = "Kapan Saja",
                TransactionValue = "Rp 2.000.000",
                CreditLimit = "Rp 2.500.000",
                Payment = "Bank Indonesia",
                Guarantee = "BPOM",
                Status = EStatusCredit.ManagementRisk,
                FlagRead = true,
                FlagFine = true,
                CreatedBy = 1,
                Currency = "Rp",
                TransactionValueEstimatedPeriod = "Perbulan Pengeluaran",
                TrCaActionNote = new List<TrCaActionNote>(),
                TrCaProducts = new List<TrCaProduct>(),
                TrCaNotes = new List<TrCaNote>(),
                CaCustomerDetails = new List<CaCustomerDetail>(),
                QuantitativeAspects = new List<QuantitativeAspect>(),
                CreditScorings = new List<CreditScoring>(),
                User = new User()
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "admin@covalmor1.com",
                    Jabatan = "Komisaris",
                    Password = PasswordHash.GetHash("12345678"),
                    Role = EUserRole.Admin
                }
            });
            CreditApprovals.Add(new CreditApproval()
            {
                Id = 6,
                TicketNumber = "44667788",
                MailNumber = "1122334455",
                CustomerId = 1,
                TempoStart = Convert.ToDateTime("01/12/2019"),
                TempoEnd = Convert.ToDateTime("05/05/2020"),
                LongTempo = "Perbulan 1 kali",
                Volume = "2 Liter",
                Units = "Per Kg",
                PeriodeVolume = "Perbulan Volume",
                SubmissionPeriod = "Kapan Saja",
                TransactionValue = "Rp 2.000.000",
                CreditLimit = "Rp 2.500.000",
                Payment = "Bank Indonesia",
                Guarantee = "BPOM",
                Status = EStatusCredit.KomiteCredit,
                FlagRead = true,
                FlagFine = true,
                CreatedBy = 1,
                Currency = "Rp",
                TransactionValueEstimatedPeriod = "Perbulan Pengeluaran",
                TrCaActionNote = new List<TrCaActionNote>(),
                TrCaProducts = new List<TrCaProduct>(),
                TrCaNotes = new List<TrCaNote>(),
                CaCustomerDetails = new List<CaCustomerDetail>(),
                QuantitativeAspects = new List<QuantitativeAspect>(),
                CreditScorings = new List<CreditScoring>(),
                User = new User()
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "admin@covalmor1.com",
                    Jabatan = "Komisaris",
                    Password = PasswordHash.GetHash("12345678"),
                    Role = EUserRole.Admin
                }
            });
            #endregion

            #region tr ca note dummy data
            TrCaNotes.Add(new TrCaNote()
            {
                Id = 1,
                CreditApprovalId = 1,
                TanggalNota = Convert.ToDateTime("12/12/2019"),
                Perihal = "Pesan Dari FBS",
                Isi = "Data ini valid",
                CreatedBy = "Admin",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
            TrCaNotes.Add(new TrCaNote()
            {
                Id = 2,
                CreditApprovalId = 2,
                TanggalNota = Convert.ToDateTime("12/12/2019"),
                Perihal = "Pesan Dari FBS",
                Isi = "Data ini valid",
                CreatedBy = "Admin",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
            TrCaNotes.Add(new TrCaNote()
            {
                Id = 3,
                CreditApprovalId = 3,
                TanggalNota = Convert.ToDateTime("12/12/2019"),
                Perihal = "Pesan Dari FBS",
                Isi = "Data ini valid",
                CreatedBy = "Admin",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
            #endregion
        }

        #region db set
        public DbSet<Product> Products { get; set; }

        public DbSet<CreditApproval> CreditApprovals { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<StaticValue> StaticValues { get; set; }

        public DbSet<TrCaActionNote> TrCaActionNotes { get; set; }

        public DbSet<TrCaProduct> TrCaProducts { get; set; }

        public DbSet<Signature> Signatures { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<CaCustomerDetail> CaCustomerDetails { get; set; }

        public DbSet<TrCaNote> TrCaNotes { get; set; }

        public DbSet<CreditScoring> CreditScorings { get; set; }

        public DbSet<QuantitativeAspect> QuantitativeAspects { get; set; }

        public Database Database => throw new NotImplementedException();
        #endregion

        public int SaveChanges()
        {
            return 0;
        }
    }
}
