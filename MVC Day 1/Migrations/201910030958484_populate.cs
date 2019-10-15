namespace MVC_Day_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populate : DbMigration
    {
        public override void Up()
        {
            Sql("insert MembershipTypes(Type,Duration,SignUpFee,Discount) values('Yearly',12,1500,15)");
            Sql("insert MembershipTypes(Type,Duration,SignUpFee,Discount) values('Half-Yearly',6,750,10)");
            Sql("insert MembershipTypes(Type,Duration,SignUpFee,Discount) values('Quaterly',4,500,5)");

        }
        
        public override void Down()
        {
        }
    }
}
