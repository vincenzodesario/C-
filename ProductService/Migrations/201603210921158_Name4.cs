namespace ProductService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Name4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Name4", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Name4");
        }
    }
}
