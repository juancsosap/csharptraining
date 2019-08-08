namespace BlogSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingComments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Publication = c.DateTime(nullable: false),
                        BlogPostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogPosts", t => t.BlogPostId, cascadeDelete: true)
                .Index(t => t.BlogPostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "BlogPostId", "dbo.BlogPosts");
            DropIndex("dbo.Comments", new[] { "BlogPostId" });
            DropTable("dbo.Comments");
        }
    }
}
