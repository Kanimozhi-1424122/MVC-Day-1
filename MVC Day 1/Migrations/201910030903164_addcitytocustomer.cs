namespace MVC_Day_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcitytocustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.customers", "city", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.customers", "city");
        }
    }
}
