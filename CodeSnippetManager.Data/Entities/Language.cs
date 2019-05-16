using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeSnippetManager.DataAccess.Entities
{
    public class Language
    {
        public Language()
        {
            this.Snippets = new ObservableCollection<Snippet>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        [InverseProperty("Language")]
        public virtual ICollection<Snippet> Snippets { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Language language 
                && this.Name == language.Name
                && this.Description == language.Description;
        }

        public override int GetHashCode()
        {
            var hashCode = 17;
            hashCode = hashCode * 37 + (this.Name == null ? 0 : this.Name.GetHashCode());
            hashCode = hashCode * 37 + (this.Description == null ? 0 : this.Description.GetHashCode());
            return hashCode;
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.Description}";
        }
    }
}
