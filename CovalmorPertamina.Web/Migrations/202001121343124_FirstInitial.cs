namespace CovalmorPertamina.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CaCustomerDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreditApprovalId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        JenisIndustri = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Keterlambatan = c.String(nullable: false, maxLength: 191, unicode: false),
                        Restrukturisasi = c.String(nullable: false, maxLength: 191, unicode: false),
                        FasilitasKredit = c.String(nullable: false, maxLength: 191, unicode: false),
                        LamaKerjaSama = c.String(nullable: false, maxLength: 191, unicode: false),
                        VendorPemasuk = c.String(nullable: false, maxLength: 191, unicode: false),
                        PosisiTawar = c.String(nullable: false, maxLength: 191, unicode: false),
                        BadanUsaha = c.String(nullable: false, maxLength: 191, unicode: false),
                        Affiliasi = c.String(nullable: false, maxLength: 191, unicode: false),
                        KondisiIndustri = c.String(nullable: false, maxLength: 191, unicode: false),
                        OpiniAudit = c.String(nullable: false, maxLength: 191, unicode: false),
                        AuditKap = c.String(nullable: false, maxLength: 191, unicode: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        ScoreRiwayatPembayaran = c.Int(nullable: false),
                        ScoreRiwayatRestrukturisasi = c.Int(nullable: false),
                        ScoreFasilitasKreditBank = c.Int(nullable: false),
                        ScoreLamaBekerjaSama = c.Int(nullable: false),
                        ScoreVendorPemasok = c.Int(nullable: false),
                        ScorePosisiTawarPertaminaCustomer = c.Int(nullable: false),
                        ScoreBadanHukumUsaha = c.Int(nullable: false),
                        ScoreNetworkingAP = c.Int(nullable: false),
                        ScoreKondisiIndustriCustomer = c.Int(nullable: false),
                        ScoreOpiniAudit = c.Int(nullable: false),
                        ScoreAuditorTerdaftarOJK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditApprovals", t => t.CreditApprovalId, cascadeDelete: true)
                .Index(t => t.CreditApprovalId);
            
            CreateTable(
                "dbo.CreditApprovals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketNumber = c.String(nullable: false, maxLength: 45, unicode: false),
                        MailNumber = c.String(nullable: false, maxLength: 45, unicode: false),
                        CustomerId = c.Int(nullable: false),
                        TempoStart = c.DateTime(nullable: false, storeType: "date"),
                        TempoEnd = c.DateTime(nullable: false, storeType: "date"),
                        LongTempo = c.String(nullable: false, maxLength: 191, unicode: false),
                        Volume = c.String(nullable: false, maxLength: 191, unicode: false),
                        Units = c.String(nullable: false, maxLength: 191, unicode: false),
                        PeriodeVolume = c.String(nullable: false, maxLength: 191, unicode: false),
                        SubmissionPeriod = c.String(nullable: false, maxLength: 191, unicode: false),
                        TransactionValue = c.String(nullable: false, maxLength: 191, unicode: false),
                        CreditLimit = c.String(nullable: false, maxLength: 191, unicode: false),
                        Payment = c.String(nullable: false, maxLength: 191, unicode: false),
                        Guarantee = c.String(nullable: false, maxLength: 191, unicode: false),
                        IntroductionToMemo = c.String(maxLength: 191, unicode: false),
                        DocLka = c.String(maxLength: 191, unicode: false),
                        DocCas = c.String(maxLength: 191, unicode: false),
                        DocBg = c.String(maxLength: 191, unicode: false),
                        DocPml = c.String(maxLength: 191, unicode: false),
                        BankGuaranteeDoc = c.String(maxLength: 191, unicode: false),
                        BankConfirmationDoc = c.String(maxLength: 191, unicode: false),
                        CreditScoringDoc = c.String(maxLength: 191, unicode: false),
                        CreditApprovalDoc = c.String(maxLength: 191, unicode: false),
                        FlagFine = c.Boolean(nullable: false),
                        TermsOfDelivery = c.String(nullable: false, maxLength: 191, unicode: false),
                        Status = c.Int(nullable: false),
                        FlagRead = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        Currency = c.String(),
                        TransactionValueEstimatedPeriod = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CreatedBy, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.CreditScorings",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CreditApporvalId = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CustomerName = c.String(),
                        CustomerSap = c.String(),
                        TypeIndustry = c.String(),
                        Score = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditApprovals", t => t.CreditApporvalId, cascadeDelete: true)
                .Index(t => t.CreditApporvalId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerNo = c.String(nullable: false, maxLength: 191, unicode: false),
                        Name = c.String(nullable: false, maxLength: 191, unicode: false),
                        Email = c.String(nullable: false, maxLength: 191, unicode: false),
                        Address = c.String(nullable: false, maxLength: 191, unicode: false),
                        NPWP = c.String(nullable: false, maxLength: 191, unicode: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuantitativeAspects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreditApporvalId = c.Int(nullable: false),
                        DateTime1 = c.DateTime(nullable: false),
                        DateTime2 = c.DateTime(nullable: false),
                        ReportCastIsAviable = c.Boolean(nullable: false),
                        CashAndCashEquivalents1 = c.Single(nullable: false),
                        CashAndCashEquivalents2 = c.Single(nullable: false),
                        ShortTermInvestment1 = c.Single(nullable: false),
                        ShortTermInvestment2 = c.Single(nullable: false),
                        ReceivablesIncludingRelatedReceivables1 = c.Single(nullable: false),
                        ReceivablesIncludingRelatedReceivables2 = c.Single(nullable: false),
                        Stock1 = c.Single(nullable: false),
                        Stock2 = c.Single(nullable: false),
                        PrepaidExpenses1 = c.Single(nullable: false),
                        PrepaidExpenses2 = c.Single(nullable: false),
                        PrepaidTaxes1 = c.Single(nullable: false),
                        PrepaidTaxes2 = c.Single(nullable: false),
                        OtherCash1 = c.Single(nullable: false),
                        OtherCash2 = c.Single(nullable: false),
                        IntangibleAssetsAmortizationGoodwill1 = c.Single(nullable: false),
                        IntangibleAssetsAmortizationGoodwill2 = c.Single(nullable: false),
                        TotalAssets1 = c.Single(nullable: false),
                        TotalAssets2 = c.Single(nullable: false),
                        TotalShortTermDebtLiabilities1 = c.Single(nullable: false),
                        TotalShortTermDebtLiabilities2 = c.Single(nullable: false),
                        InterestBearingPayables1 = c.Single(nullable: false),
                        InterestBearingPayables2 = c.Single(nullable: false),
                        TotalAmountOfDebt1 = c.Single(nullable: false),
                        TotalAmountOfDebt2 = c.Single(nullable: false),
                        TotalCapitalEquity1 = c.Single(nullable: false),
                        TotalCapitalEquity2 = c.Single(nullable: false),
                        SalesRevenue1 = c.Single(nullable: false),
                        SalesRevenue2 = c.Single(nullable: false),
                        CostOfGoodsDirectCharges1 = c.Single(nullable: false),
                        CostOfGoodsDirectCharges2 = c.Single(nullable: false),
                        AdministrativeBurden1 = c.Single(nullable: false),
                        AdministrativeBurden2 = c.Single(nullable: false),
                        FinancialRevenuesExpenses1 = c.Single(nullable: false),
                        FinancialRevenuesExpenses2 = c.Single(nullable: false),
                        TaxExpense1 = c.Single(nullable: false),
                        TaxExpense2 = c.Single(nullable: false),
                        OtherIncomeExpenses1 = c.Single(nullable: false),
                        OtherIncomeExpenses2 = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditApprovals", t => t.CreditApporvalId, cascadeDelete: true)
                .Index(t => t.CreditApporvalId);
            
            CreateTable(
                "dbo.TrCaActionNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreditApprovalId = c.Int(nullable: false),
                        ActionNote = c.String(maxLength: 191, unicode: false),
                        ActionType = c.Byte(nullable: false),
                        ActionBy = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditApprovals", t => t.CreditApprovalId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ActionBy, cascadeDelete: false)
                .Index(t => t.CreditApprovalId)
                .Index(t => t.ActionBy);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 191, unicode: false),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Jabatan = c.String(maxLength: 191, unicode: false),
                        Password = c.String(nullable: false),
                        Role = c.Int(nullable: false),
                        EmailVerifiedAt = c.DateTime(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.TrCaNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreditApprovalId = c.Int(nullable: false),
                        TanggalNota = c.DateTime(nullable: false),
                        Perihal = c.String(nullable: false, maxLength: 45, unicode: false),
                        Isi = c.String(nullable: false, unicode: false, storeType: "text"),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditApprovals", t => t.CreditApprovalId, cascadeDelete: true)
                .Index(t => t.CreditApprovalId);
            
            CreateTable(
                "dbo.TrCaProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreditApprovalId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditApprovals", t => t.CreditApprovalId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CreditApprovalId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaterialNo = c.String(maxLength: 191, unicode: false),
                        MaterialName = c.String(nullable: false, maxLength: 191, unicode: false),
                        MaterialGroup = c.String(nullable: false, maxLength: 191, unicode: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Signatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name1 = c.String(nullable: false, maxLength: 191, unicode: false),
                        Name2 = c.String(nullable: false, maxLength: 191, unicode: false),
                        Position1 = c.String(nullable: false, maxLength: 191, unicode: false),
                        Position2 = c.String(nullable: false, maxLength: 191, unicode: false),
                        DocumentType = c.String(nullable: false, maxLength: 191, unicode: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StaticValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false, maxLength: 45, unicode: false),
                        TextValue = c.String(nullable: false, maxLength: 8000, unicode: false),
                        ColumnScore = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditApprovals", "CreatedBy", "dbo.Users");
            DropForeignKey("dbo.TrCaProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.TrCaProducts", "CreditApprovalId", "dbo.CreditApprovals");
            DropForeignKey("dbo.TrCaNotes", "CreditApprovalId", "dbo.CreditApprovals");
            DropForeignKey("dbo.TrCaActionNotes", "ActionBy", "dbo.Users");
            DropForeignKey("dbo.TrCaActionNotes", "CreditApprovalId", "dbo.CreditApprovals");
            DropForeignKey("dbo.QuantitativeAspects", "CreditApporvalId", "dbo.CreditApprovals");
            DropForeignKey("dbo.CreditApprovals", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CreditScorings", "CreditApporvalId", "dbo.CreditApprovals");
            DropForeignKey("dbo.CaCustomerDetails", "CreditApprovalId", "dbo.CreditApprovals");
            DropIndex("dbo.TrCaProducts", new[] { "ProductId" });
            DropIndex("dbo.TrCaProducts", new[] { "CreditApprovalId" });
            DropIndex("dbo.TrCaNotes", new[] { "CreditApprovalId" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.TrCaActionNotes", new[] { "ActionBy" });
            DropIndex("dbo.TrCaActionNotes", new[] { "CreditApprovalId" });
            DropIndex("dbo.QuantitativeAspects", new[] { "CreditApporvalId" });
            DropIndex("dbo.CreditScorings", new[] { "CreditApporvalId" });
            DropIndex("dbo.CreditApprovals", new[] { "CreatedBy" });
            DropIndex("dbo.CreditApprovals", new[] { "CustomerId" });
            DropIndex("dbo.CaCustomerDetails", new[] { "CreditApprovalId" });
            DropTable("dbo.StaticValues");
            DropTable("dbo.Signatures");
            DropTable("dbo.Products");
            DropTable("dbo.TrCaProducts");
            DropTable("dbo.TrCaNotes");
            DropTable("dbo.Users");
            DropTable("dbo.TrCaActionNotes");
            DropTable("dbo.QuantitativeAspects");
            DropTable("dbo.Customers");
            DropTable("dbo.CreditScorings");
            DropTable("dbo.CreditApprovals");
            DropTable("dbo.CaCustomerDetails");
        }
    }
}
