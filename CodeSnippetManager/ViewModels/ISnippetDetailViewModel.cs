using System.Threading.Tasks;

namespace CodeSnippetManager.UI.ViewModels
{
    public interface ISnippetDetailViewModel
    {
        Task LoadAsync(int snippetId);
    }
}