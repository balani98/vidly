namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wantToYpdateValue : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MEMBERSHIPTYPES SET MembershipTypeName='Pay As You Go' WHERE id=1 ");
        }
        
        public override void Down()
        {
        }
    }
}
