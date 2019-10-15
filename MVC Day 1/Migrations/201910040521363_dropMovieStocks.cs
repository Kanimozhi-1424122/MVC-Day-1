namespace MVC_Day_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropMovieStocks : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.MovieStocks");
        }
        
        public override void Down()
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
    }
}
