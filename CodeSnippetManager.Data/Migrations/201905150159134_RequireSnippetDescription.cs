namespace CodeSnippetManager.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequireSnippetDescription : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Snippet", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Snippet", "Description", c => c.String());
        }
    }
}
