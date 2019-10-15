namespace MVC_Day_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMemberShip : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.customers", "MemberShipTypeId", c => c.Int(nullable: true));
            CreateIndex("dbo.customers", "MemberShipTypeId");
            AddForeignKey("dbo.customers", "MemberShipTypeId", "dbo.MemberShipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.customers", "MemberShipTypeId", "dbo.MemberShipTypes");
            DropIndex("dbo.customers", new[] { "MemberShipTypeId" });
            DropColumn("dbo.customers", "MemberShipTypeId");
        }
    }
}
