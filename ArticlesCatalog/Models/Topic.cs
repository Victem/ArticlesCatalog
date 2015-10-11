using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesCatalog.Models
{
    public class Topic
    {
        [Key]
        public int TopicID { get; set; }

        [Index(IsUnique=true)]
        [StringLength(200)]
        public string TopicName { get; set; }

        [ForeignKey("Parent")]
        public int? ParentID { get; set; }

       
        public virtual Topic Parent { get; set; }

        public virtual ICollection<Topic> Childs { get; set; } = new List<Topic>();

        public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
