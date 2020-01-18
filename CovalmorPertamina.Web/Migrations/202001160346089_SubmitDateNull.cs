namespace CovalmorPertamina.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubmitDateNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CreditApprovals", "SubmitArDate", c => c.DateTime());
            AlterColumn("dbo.CreditApprovals", "SubmitCbDate", c => c.DateTime());
            AlterColumn("dbo.CreditApprovals", "SubmitFbsDate", c => c.DateTime());
            AlterColumn("dbo.CreditApprovals", "SubmitMrDate", c => c.DateTime());
            AlterColumn("dbo.CreditApprovals", "SubmitKKDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CreditApprovals", "SubmitKKDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CreditApprovals", "SubmitMrDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CreditApprovals", "SubmitFbsDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CreditApprovals", "SubmitCbDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CreditApprovals", "SubmitArDate", c => c.DateTime(nullable: false));
        }
    }
}
