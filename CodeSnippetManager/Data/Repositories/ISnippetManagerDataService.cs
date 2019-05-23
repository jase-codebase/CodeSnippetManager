using CodeSnippetManager.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeSnippetManager.UI.Data
{
    public interface ISnippetManagerDataService : IDisposable
    {
        Task<Snippet> GetByIdAsync(int snippetId);
        Task SaveAsync(Snippet snippet);
    }
}