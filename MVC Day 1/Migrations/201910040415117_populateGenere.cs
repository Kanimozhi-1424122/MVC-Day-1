namespace MVC_Day_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenere : DbMigration
    {
        public override void Up()
        {
            Sql("insert MemberShipGneres(GenereName)values('WomenSports')");
            Sql("insert MemberShipGneres(GenereName)values('Politics')");
            Sql("insert MemberShipGneres(GenereName)values('Horror')");
          
        }
        
        public override void Down()
        {
        }
    }
}
