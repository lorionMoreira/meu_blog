using blog_asp_net2.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_asp_net2.Persistence.Contratos
{
    public interface IPostPersist
    {
        Task<Post[]> GetAllPostsAsync();
        Task<Post> GetPostByIdAsync(int postId);
    }
}
