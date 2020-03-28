namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class membershipTypeNameAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "membershipTypeName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "membershipTypeName");
        }
    }
}
