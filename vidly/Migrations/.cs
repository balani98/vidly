namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateColumnAddedInCustomerAsNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "dob", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "dob", c => c.DateTime(nullable: false));
        }
    }
}
