namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddedNewColumnsInMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "releaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "dateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "StockNo", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "genre_Id", c => c.Int());
            CreateIndex("dbo.Movies", "genre_Id");
            AddForeignKey("dbo.Movies", "genre_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "genre_Id" });
            DropColumn("dbo.Movies", "genre_Id");
            DropColumn("dbo.Movies", "StockNo");
            DropColumn("dbo.Movies", "dateAdded");
            DropColumn("dbo.Movies", "releaseDate");
            DropTable("dbo.Genres");
        }
    }
}
