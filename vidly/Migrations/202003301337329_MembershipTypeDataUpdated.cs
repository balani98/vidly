namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembershipTypeDataUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "genre_Id" });
            AddColumn("dbo.Movies", "genre_Id1", c => c.Int());
            AlterColumn("dbo.Movies", "genre_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "genre_Id1");
            AddForeignKey("dbo.Movies", "genre_Id1", "dbo.Genres", "Id");
            DropColumn("dbo.Movies", "genreId");
            Sql("INSERT INTO MEMBERSHIPTYPES(id,signUpFee,durationInMonths,discountRate) VALUES(1,0,0,0)");
            Sql("INSERT INTO MEMBERSHIPTYPES(id,signUpFee,durationInMonths,discountRate) VALUES(2,30,1,10)");
            Sql("INSERT INTO MEMBERSHIPTYPES(id,signUpFee,durationInMonths,discountRate) VALUES(3,90,3,15)");
            Sql("INSERT INTO MEMBERSHIPTYPES(id,signUpFee,durationInMonths,discountRate) VALUES(4,300,12,20)");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "genreId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Movies", "genre_Id1", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "genre_Id1" });
            AlterColumn("dbo.Movies", "genre_Id", c => c.Int());
            DropColumn("dbo.Movies", "genre_Id1");
            CreateIndex("dbo.Movies", "genre_Id");
            AddForeignKey("dbo.Movies", "genre_Id", "dbo.Genres", "Id");
        }
    }
}
