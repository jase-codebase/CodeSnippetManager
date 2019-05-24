using CodeSnippetManager.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeSnippetManager.UI.Data.Repositories
{
    public interface ISnippetManagerRepository : IDisposable
    {
        Task<Snippet> GetByIdAsync(int snippetId);
        Task SaveAsync();
        bool HasChanges();
    }
}