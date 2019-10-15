namespace MVC_Day_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropDirectorNamefromMovie : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "DirectorName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "DirectorName", c => c.String());
        }
    }
}
