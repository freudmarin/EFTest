namespace EFDbFirstApproachExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Brand2", "BrandName", c => c.String(nullable: false));
            AlterColumn("dbo.Category2", "CategoryName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Category2", "CategoryName", c => c.String());
            AlterColumn("dbo.Brand2", "BrandName", c => c.String());
        }
    }
}
