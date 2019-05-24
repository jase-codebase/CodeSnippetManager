using CodeSnippetManager.DataAccess;
using CodeSnippetManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippetManager.UI.Data.Repositories
{
    public class SnippetManagerRepository : ISnippetManagerRepository
    {
        private CodeSnippetManagerContext _context;

        public SnippetManagerRepository(CodeSnippetManagerContext context)
        {
            _context = context;
        }

        public async Task<Snippet> GetByIdAsync(int snippetId)
        {
            return await _context.CodeSnippets.SingleAsync(s => s.Id == snippetId);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._context?.Dispose();
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }


        private static IEnumerable<Snippet> GetHardcoded()
        {
            Tag iotag = new Tag
            {
                Id = 0,
                Name = "I/O"
            };
            Tag filetag = new Tag
            {
                Id = 1,
                Name = "File"
            };
            ObservableCollection<Tag> tags = new ObservableCollection<Tag> { iotag, filetag };
            yield return new Snippet
            {
                Id = 0,
                Language = new Language { Id = 0, Name = "C#", Description = "is a general-purpose, multi-paradigm programming language encompassing strong typing, lexically scoped, imperative, declarative, functional, generic, object-oriented (class-based), and component-oriented programming disciplines.  It was developed by Microsoft and first released in 2001" },
                LanguageId = 0,
                Text = @"string path = C:\fileToRead.txt;" + Environment.NewLine + "string fileText = System.IO.File.ReadAllText(path);",
                Tags = tags,
                Description = "Opens a file, reads all of the text into a string, and then closes the file."
            };

            Tag reflection = new Tag { Id = 2, Name = "Reflection" };
            Tag assembly = new Tag { Id = 3, Name = "Assembly" };
            ObservableCollection<Tag> tags1 = new ObservableCollection<Tag> { reflection, assembly };
            yield return new Snippet
            {
                Id = 1,
                Language = new Language { Id = 0, Name = "C#", Description = "is a general-purpose, multi-paradigm programming language encompassing strong typing, lexically scoped, imperative, declarative, functional, generic, object-oriented (class-based), and component-oriented programming disciplines.  It was developed by Microsoft and first released in 2001" },
                LanguageId = 0,
                Text = @"string localPath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;",
                Tags = tags1,
                Description = "Get the location of the currently executing assembly."
            };

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("#include <stdio.h>");
            sb.AppendLine("#include <stdlib.h>");
            sb.AppendLine();
            sb.AppendLine("/* String Length */");
            sb.AppendLine("int str_len(char * string)");
            sb.AppendLine("{");
            sb.AppendLine("    char* count = string;");
            sb.AppendLine("    while (*count)");
            sb.AppendLine("    { count++; }");
            sb.AppendLine("    return count - string;");
            sb.AppendLine("}");
            string snippet = sb.ToString();
            Tag strFunction = new Tag { Id = 4, Name = "String Functions" };
            ObservableCollection<Tag> tags2 = new ObservableCollection<Tag> { strFunction };
            yield return new Snippet
            {
                Id = 2,
                Language = new Language
                {
                    Id = 1,
                    Name = "C++",
                    Description = "C++ is a general - purpose programming language that was developed by Bjarne Stroustrup as " +
                    "an extension of the C language, or \"C with Classes\". It has imperative, object-oriented and generic programming " +
                    "features, while also providing facilities for low-level memory manipulation."
                },
                LanguageId = 1,
                Text = snippet,
                Tags = tags2,
                Description = "Gets the length of the specified string."
            };
        }
    }
}
