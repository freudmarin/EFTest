namespace EFDbFirstApproachExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brand2",
                c => new
                    {
                        BrandID = c.Long(nullable: false, identity: true),
                        BrandName = c.String(),
                    })
                .PrimaryKey(t => t.BrandID);
            
            CreateTable(
                "dbo.Product2",
                c => new
                    {
                        ProductID = c.Long(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        DateOfPurchase = c.DateTime(),
                        AvailabilityStatus = c.String(),
                        CategoryID = c.Long(),
                        BrandID = c.Long(),
                        Active = c.Boolean(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Brand2", t => t.BrandID)
                .ForeignKey("dbo.Category2", t => t.CategoryID)
                .Index(t => t.CategoryID)
                .Index(t => t.BrandID);
            
            CreateTable(
                "dbo.Category2",
                c => new
                    {
                        CategoryID = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product2", "CategoryID", "dbo.Category2");
            DropForeignKey("dbo.Product2", "BrandID", "dbo.Brand2");
            DropIndex("dbo.Product2", new[] { "BrandID" });
            DropIndex("dbo.Product2", new[] { "CategoryID" });
            DropTable("dbo.Category2");
            DropTable("dbo.Product2");
            DropTable("dbo.Brand2");
        }
    }
}
