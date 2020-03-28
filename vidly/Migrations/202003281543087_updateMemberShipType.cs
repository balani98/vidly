namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMemberShipType : DbMigration
    {
        public override void Up()
        {  
            Sql("UPDATE MEMBERSHIPTYPES SET MembershipTypeName='Pay As You Go' WHERE id=1 ");
            Sql("UPDATE MEMBERSHIPTYPES SET MembershipTypeName='Monthly' WHERE id=2 ");
            Sql("UPDATE MEMBERSHIPTYPES SET MembershipTypeName='Quaterly' WHERE id=3 ");
            Sql("UPDATE MEMBERSHIPTYPES SET MembershipTypeName='Quaterly' WHERE id=4 ");
            
        }
        public override void Down()
        {
        }
    }
}
