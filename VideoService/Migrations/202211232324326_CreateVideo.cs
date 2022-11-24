namespace VideoService.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateVideo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        IsProcessed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);

            Sql("INSERT INTO Videos VALUES ('Video1', 'TRUE')");
            Sql("INSERT INTO Videos VALUES ('Video2', 'FALSE')");
            Sql("INSERT INTO Videos VALUES ('Video3', 'FALSE')");
            Sql("INSERT INTO Videos VALUES ('Video4', 'TRUE')");
        }
        
        public override void Down()
        {
            DropTable("dbo.Videos");
        }
    }
}
