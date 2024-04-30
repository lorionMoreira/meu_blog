using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_asp_net2.Domain
{
    public class Comment
    {
        public int id { get; set; }
        public string message { get; set; }

        public Post post { get; set; }

    }
}
