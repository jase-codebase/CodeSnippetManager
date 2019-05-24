using System.Collections.Generic;
using System.Threading.Tasks;
using CodeSnippetManager.Model;
using CodeSnippetManager.UI.ViewModels;

namespace CodeSnippetManager.UI.Data.Lookups
{
    public interface ICodeSnippetLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetCodeSnippetLookupAsync();
    }
}