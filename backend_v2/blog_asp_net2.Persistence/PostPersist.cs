﻿using blog_asp_net2.Domain;
using blog_asp_net2.Persistence.Contextos;
using blog_asp_net2.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_asp_net2.Persistence
{
    public class PostPersist : IPostPersist
    {

        private readonly DataContext _context;
        public PostPersist(DataContext context)
        {
            _context = context;
            // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        public async Task<Post[]> GetAllPostsAsync()
        {
            return await _context.Posts.ToArrayAsync();
        }

        public async Task<Post> GetPostByIdAsync(int postId)
        {
            return await _context.Posts.FirstOrDefaultAsync(p => p.id == postId);
        }
    }
}

