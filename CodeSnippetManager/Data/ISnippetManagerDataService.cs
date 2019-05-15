using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeSnippetManager.DataAccess.Entities;

namespace CodeSnippetManager.UI.Data
{
    public interface ISnippetManagerDataService : IDisposable
    {
        Task<Snippet> GetByIdAsync(int snippetId);
        Task SaveAsync(Snippet snippet);
    }
}