namespace ProductService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeColumns : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "PriceAfterDepDev");
            DropColumn("dbo.Products", "PriceAfterDepDev1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "PriceAfterDepDev1", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "PriceAfterDepDev", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
