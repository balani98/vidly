namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateOfBirthAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "dateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "dateOfBirth");
        }
    }
}
