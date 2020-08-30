namespace EFDbFirstApproachExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product2", "BrandID", "dbo.Brand2");
            DropForeignKey("dbo.Product2", "CategoryID", "dbo.Category2");
            DropIndex("dbo.Product2", new[] { "CategoryID" });
            DropIndex("dbo.Product2", new[] { "BrandID" });
            AlterColumn("dbo.Product2", "ProductName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Product2", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Product2", "CategoryID", c => c.Long(nullable: false));
            AlterColumn("dbo.Product2", "BrandID", c => c.Long(nullable: false));
            CreateIndex("dbo.Product2", "CategoryID");
            CreateIndex("dbo.Product2", "BrandID");
            AddForeignKey("dbo.Product2", "BrandID", "dbo.Brand2", "BrandID", cascadeDelete: true);
            AddForeignKey("dbo.Product2", "CategoryID", "dbo.Category2", "CategoryID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product2", "CategoryID", "dbo.Category2");
            DropForeignKey("dbo.Product2", "BrandID", "dbo.Brand2");
            DropIndex("dbo.Product2", new[] { "BrandID" });
            DropIndex("dbo.Product2", new[] { "CategoryID" });
            AlterColumn("dbo.Product2", "BrandID", c => c.Long());
            AlterColumn("dbo.Product2", "CategoryID", c => c.Long());
            AlterColumn("dbo.Product2", "Price", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Product2", "ProductName", c => c.String());
            CreateIndex("dbo.Product2", "BrandID");
            CreateIndex("dbo.Product2", "CategoryID");
            AddForeignKey("dbo.Product2", "CategoryID", "dbo.Category2", "CategoryID");
            AddForeignKey("dbo.Product2", "BrandID", "dbo.Brand2", "BrandID");
        }
    }
}
