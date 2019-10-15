namespace MVC_Day_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropGenre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "MemberShipGnere_Id", "dbo.MemberShipGneres");
            DropIndex("dbo.Movies", new[] { "MemberShipGnere_Id" });
            DropColumn("dbo.Movies", "MemeberShipGnereId");
            DropColumn("dbo.Movies", "MemberShipGnere_Id");
            DropTable("dbo.MemberShipGneres");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MemberShipGneres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenereName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "MemberShipGnere_Id", c => c.Int());
            AddColumn("dbo.Movies", "MemeberShipGnereId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "MemberShipGnere_Id");
            AddForeignKey("dbo.Movies", "MemberShipGnere_Id", "dbo.MemberShipGneres", "Id");
        }
    }
}
