namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dobColumnDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "dob");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "dob", c => c.DateTime());
        }
    }
}
