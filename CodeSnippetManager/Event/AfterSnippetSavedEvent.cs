using Prism.Events;

namespace CodeSnippetManager.UI.Event
{
    public class AfterSnippetSavedEvent : PubSubEvent<AfterSnippetSavedEventArgs>
    {
    }

    public class AfterSnippetSavedEventArgs
    {
        public int Id { get; set; }
        public string DisplayMember { get; set; }
    }
}
