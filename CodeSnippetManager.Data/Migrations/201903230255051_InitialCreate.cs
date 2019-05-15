namespace CodeSnippetManager.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Snippet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        Description = c.String(),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);

            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);

            CreateTable(
                "dbo.SnippetTag",
                c => new
                    {
                        SnippetRefId = c.Int(nullable: false),
                        TagRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SnippetRefId, t.TagRefId })
                .ForeignKey("dbo.Snippet", t => t.SnippetRefId, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.TagRefId, cascadeDelete: true)
                .Index(t => t.SnippetRefId)
                .Index(t => t.TagRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SnippetTag", "TagRefId", "dbo.Tag");
            DropForeignKey("dbo.SnippetTag", "SnippetRefId", "dbo.Snippet");
            DropForeignKey("dbo.Snippet", "LanguageId", "dbo.Language");
            DropIndex("dbo.SnippetTag", new[] { "TagRefId" });
            DropIndex("dbo.SnippetTag", new[] { "SnippetRefId" });
            DropIndex("dbo.Tag", new[] { "Name" });
            DropIndex("dbo.Language", new[] { "Name" });
            DropIndex("dbo.Snippet", new[] { "LanguageId" });
            DropTable("dbo.SnippetTag");
            DropTable("dbo.Tag");
            DropTable("dbo.Language");
            DropTable("dbo.Snippet");
        }
    }
}
