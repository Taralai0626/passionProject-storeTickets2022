namespace passionProject_storeTickets2022.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchasePrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "PurchasePrice", c => c.Double(nullable: false));
            DropColumn("dbo.Purchases", "PurchacePrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchases", "PurchacePrice", c => c.Double(nullable: false));
            DropColumn("dbo.Purchases", "PurchasePrice");
        }
    }
}
