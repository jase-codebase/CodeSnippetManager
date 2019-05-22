using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeSnippetManager.Model
{
    public class Snippet
    {
        public Snippet()
        {
            this.Tags = new ObservableCollection<Tag>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public virtual string Text { get; set; }

        [Required]
        public virtual string Description { get; set; }

        [ForeignKey("Language")]
        public virtual int LanguageId { get; set; }
        public virtual Language Language { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Snippet snippet &&
                   this.Id == snippet.Id &&
                   this.Text == snippet.Text &&
                   this.Description == snippet.Description &&
                   this.LanguageId == snippet.LanguageId &&
                   this.Language.Equals(snippet.Language);
        }

        public override int GetHashCode()
        {
            var hashCode = -1054121976;
            hashCode = hashCode * -1521134295 + this.Id.GetHashCode();
            hashCode = hashCode * -1521134295 + (this.Text == null ? 0 : this.Text.GetHashCode());
            hashCode = hashCode * -1521134295 + (this.Description == null ? 0 : this.Description.GetHashCode());
            hashCode = hashCode * -1521134295 + this.LanguageId.GetHashCode();
            hashCode = hashCode * -1521134295 + (this.Language == null ? 0 : this.Language.GetHashCode());
            return hashCode;
        }
    }
}
