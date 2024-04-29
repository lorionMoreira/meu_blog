using blog_asp_net2.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_asp_net2.Application.Contratos
{
    public interface IPostService
    {


        Task<Post> AddPosts(Post model);
        Task<Post> UpdatePost(int eventoId, Post model);
        Task<Post> GetPostByIdAsync(int postId);

        Task<bool> DeletePost(int PostId);

        Task<Post[]> GetAllPostsAsync();

    }
}
