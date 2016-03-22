namespace ProductService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.String(),
                        Price2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceAfterDepDev = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceAfterDepDev1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name2 = c.String(),
                        Name3 = c.String(),
                        Category2 = c.String(),
                        SupplierId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.ProductRatings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Key = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Key);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.ProductRatings", "ProductID", "dbo.Products");
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.ProductRatings", new[] { "ProductID" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.ProductRatings");
            DropTable("dbo.Products");
        }
    }
}
