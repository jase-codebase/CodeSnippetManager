using CodeSnippetManager.DataAccess;
using CodeSnippetManager.Model;
using CodeSnippetManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippetManager.UI.Data
{
    public class LookupDataService : ICodeSnippetLookupDataService
    {
        private CodeSnippetManagerContext _context;
        private Func<CodeSnippetManagerContext> _contextCreator;

        public LookupDataService(Func<CodeSnippetManagerContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<IEnumerable<LookupItem>> GetCodeSnippetLookupAsync()
        {
            _context = _contextCreator();
            return await _context.CodeSnippets.AsNoTracking()
                .Select(s => new LookupItem
                {
                    Id = s.Id,
                    DisplayMember = s.Description
                })
                .ToListAsync();
        }
    }
}
