namespace MVC_Day_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembershipGnere : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberShipGneres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenereName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MemberShipGneres");
        }
    }
}
