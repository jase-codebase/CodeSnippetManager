namespace CodeSnippetManager.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequireLanguageDescription : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Language", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Language", "Description", c => c.String());
        }
    }
}
