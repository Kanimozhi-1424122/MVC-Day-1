namespace MVC_Day_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStocks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieStocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOfStockAvailable = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MovieStocks");
        }
    }
}
