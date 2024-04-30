﻿using System;
using System.Collections.Generic;

namespace blog_asp_net2.Domain
{
    public class Post
    {
        public int id { get; set; }
        public string message { get; set; }

        public IEnumerable<Comment> comment { get; set; }
    }
}
