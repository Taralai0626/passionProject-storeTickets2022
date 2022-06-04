﻿namespace passionProject_storeTickets2022.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class purchases : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TicketId = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        PurchacePrice = c.Double(nullable: false),
                        NumberOfTicket = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TicketId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "UserId", "dbo.Users");
            DropForeignKey("dbo.Purchases", "TicketId", "dbo.Tickets");
            DropIndex("dbo.Purchases", new[] { "TicketId" });
            DropIndex("dbo.Purchases", new[] { "UserId" });
            DropTable("dbo.Purchases");
        }
    }
}
