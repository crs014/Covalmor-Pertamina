namespace CovalmorPertamina.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubmitDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditApprovals", "SubmitArDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CreditApprovals", "SubmitCbDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CreditApprovals", "SubmitFbsDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CreditApprovals", "SubmitMrDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CreditApprovals", "SubmitKKDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CreditApprovals", "SubmitKKDate");
            DropColumn("dbo.CreditApprovals", "SubmitMrDate");
            DropColumn("dbo.CreditApprovals", "SubmitFbsDate");
            DropColumn("dbo.CreditApprovals", "SubmitCbDate");
            DropColumn("dbo.CreditApprovals", "SubmitArDate");
        }
    }
}
