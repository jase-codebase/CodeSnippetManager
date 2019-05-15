using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using CodeSnippetManager.DataAccess.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CodeSnippetManager.DataAccess
{
    public class CodeSnippetManagerContext : DbContext
    {
        public static readonly string DATABASE_NAME = "CodeSnippetManager";

        public CodeSnippetManagerContext() : base(DATABASE_NAME) { }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Snippet> CodeSnippets { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Snippet>()
                .HasMany<Tag>(t => t.Tags)
                .WithMany(s => s.Snippets)
                .Map(st =>
                {
                    st.MapLeftKey("SnippetRefId");
                    st.MapRightKey("TagRefId");
                    st.ToTable("SnippetTag");
                });

            modelBuilder.Entity<Tag>()
                .Property(t => t.Name)
                .HasMaxLength(250);

            modelBuilder.Entity<Tag>()
                .HasIndex(t => t.Name)
                .IsUnique();

            modelBuilder.Entity<Language>()
                .Property(l => l.Name)
                .HasMaxLength(250);

            modelBuilder.Entity<Language>()
                .HasIndex(l => l.Name)
                .IsUnique();
        }
    }
}
