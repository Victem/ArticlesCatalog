using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesCatalog.Models
{
    public class Article
    {
        [Key]
        public int ArticleID { get; set; }

        public string ArticleHeader { get; set; }

        public string ArticleText { get; set; }

        public DateTime PublishDate { get; set; } = DateTime.Now;

        public DateTime UpdateDate { get; set; } = DateTime.Now;

        public int TopicID { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
