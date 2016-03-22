namespace ProductService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class name1onsupplier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "Name1", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Suppliers", "Name1");
        }
    }
}
