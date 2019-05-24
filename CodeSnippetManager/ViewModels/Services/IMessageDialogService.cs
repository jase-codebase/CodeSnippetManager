namespace CodeSnippetManager.UI.ViewModels.Services
{
    public interface IMessageDialogService
    {
        MessageDialogResult ShowYesNoDialog(string message, string caption);
    }
}