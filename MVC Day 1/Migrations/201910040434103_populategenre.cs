namespace MVC_Day_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populategenre : DbMigration
    {
        public override void Up()
        {
            Sql("insert Genres(GenereName)values('Sports')");
            Sql("insert Genres(GenereName)values('Horror')");
            Sql("insert Genres(GenereName)values('Politics')");
            Sql("insert Genres(GenereName)values('Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
