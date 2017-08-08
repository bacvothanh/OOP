using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.Core.Article
{
    public class Blog : BaseArticle
    {
        public virtual ICollection<Category> Categories { get; set; }
    }
}
