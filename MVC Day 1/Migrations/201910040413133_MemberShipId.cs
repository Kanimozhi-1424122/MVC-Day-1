namespace MVC_Day_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberShipId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MemeberShipGnereId", c => c.Int(nullable: true));
            AddColumn("dbo.Movies", "MemberShipGnere_Id", c => c.Int());
            CreateIndex("dbo.Movies", "MemberShipGnere_Id");
            AddForeignKey("dbo.Movies", "MemberShipGnere_Id", "dbo.MemberShipGneres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MemberShipGnere_Id", "dbo.MemberShipGneres");
            DropIndex("dbo.Movies", new[] { "MemberShipGnere_Id" });
            DropColumn("dbo.Movies", "MemberShipGnere_Id");
            DropColumn("dbo.Movies", "MemeberShipGnereId");
        }
    }
}
