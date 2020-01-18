namespace CovalmorPertamina.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCretedAtAndUpdatedAtCreditApproval : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditApprovals", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.CreditApprovals", "UpdatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CreditApprovals", "UpdatedAt");
            DropColumn("dbo.CreditApprovals", "CreatedAt");
        }
    }
}
