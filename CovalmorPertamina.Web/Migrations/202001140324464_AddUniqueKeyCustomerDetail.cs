namespace CovalmorPertamina.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueKeyCustomerDetail : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CaCustomerDetails", new[] { "CreditApprovalId" });
            CreateIndex("dbo.CaCustomerDetails", "CreditApprovalId", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.CaCustomerDetails", new[] { "CreditApprovalId" });
            CreateIndex("dbo.CaCustomerDetails", "CreditApprovalId");
        }
    }
}
