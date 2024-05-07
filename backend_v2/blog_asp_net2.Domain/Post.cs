using System;
using System.Collections.Generic;
using blog_asp_net2.Domain.Identity;

namespace blog_asp_net2.Domain
{
    public class Post
    {
        public int id { get; set; }
        public string message { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<Comment> comment { get; set; }
    }
}
