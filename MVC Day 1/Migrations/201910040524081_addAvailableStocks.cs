namespace MVC_Day_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAvailableStocks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AvailableStocks", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "AvailableStocks");
        }
    }
}
