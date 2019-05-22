using CodeSnippetManager.DataAccess;
using CodeSnippetManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CodeSnippetManager.Data
{
    public static class Seeder
    {
        public static void SeedLanguages()
        {
            using (CodeSnippetManagerContext context = new CodeSnippetManagerContext())
            {
                Language cpp = new Language
                {
                    Name = "C++",
                    Description = "C++ is a general-purpose programming language that was developed by Bjarne Stroustrup as " +
                "an extension of the C language, or \"C with Classes\". It has imperative, object-oriented and generic programming " +
                "features, while also providing facilities for low-level memory manipulation."
                };

                Language python = new Language
                {
                    Name = "Python",
                    Description = "Python is an interpreted, high-level, general-purpose programming language. Created by Guido van " +
                    "Rossum and first released in 1991, Python has a design philosophy that emphasizes code readability, notably using " +
                    "significant whitespace. It provides constructs that enable clear programming on both small and large scales. Python " +
                    "features a dynamic type system and automatic memory management. It supports multiple programming paradigms, including " +
                    "object-oriented, imperative, functional and procedural. It also has a comprehensive standard library."
                };

                Language node = new Language
                {
                    Name = "Node.js",
                    Description = "Node.js is an open-source, cross-platform JavaScript run-time environment that executes JavaScript code " +
                    "outside of a browser. Node.js represents a \"JavaScript everywhere\" paradigm, unifying web application development around " +
                    "a single programming language, rather than different languages for server side and client side scripts."
                };

                Language sql = new Language
                {
                    Name = "SQL",
                    Description = "SQL (Structured Query Language) is a domain-specific language used in programming and designed for managing " +
                    "data held in a relational database management system (RDBMS), or for stream processing in a relational data stream management " +
                    "system (RDSMS). It is particularly useful in handling structured data where there are relations between different entities/variables " +
                    "of the data."
                };

                HashSet<Language> languages = new HashSet<Language> { cpp, python, node, sql };
                context.Languages.AddRange(languages);
                context.SaveChanges();
            }

        }

        public static void SeedFirstSnippet()
        {
            using (CodeSnippetManagerContext context = new CodeSnippetManagerContext())
            {
                Language csharp = new Language
                {
                    Name = "C#",
                    Description = "is a general-purpose, multi-paradigm programming language " +
                    "encompassing strong typing, lexically scoped, imperative, declarative, functional, generic, object-oriented " +
                    "(class-based), and component-oriented programming disciplines.  It was developed by Microsoft and first released in 2001"
                };

                Tag iotag = new Tag { Name = "I/O" };
                Tag filetag = new Tag { Name = "File" };
                ObservableCollection<Tag> tags = new ObservableCollection<Tag> { iotag, filetag };

                Snippet snippet = new Snippet
                {
                    Language = csharp,
                    Text = @"string path = C:\fileToRead.txt;" + Environment.NewLine + "string fileText = System.IO.File.ReadAllText(path);",
                    Description = "Opens a file, reads all of the text into a string, and then closes the file.",
                    Tags = tags
                };

                context.Languages.Add(csharp);
                context.SaveChanges();
                context.CodeSnippets.Add(snippet);
                context.SaveChanges();
            }
        }
    }
}
