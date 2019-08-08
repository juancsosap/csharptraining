namespace BlogSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAttributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogPosts", "Category", c => c.Int(nullable: false));
            AlterColumn("dbo.BlogPosts", "Title", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.BlogPosts", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "Content", c => c.String());
            AlterColumn("dbo.BlogPosts", "Content", c => c.String());
            AlterColumn("dbo.BlogPosts", "Title", c => c.String());
            DropColumn("dbo.BlogPosts", "Category");
        }
    }
}
