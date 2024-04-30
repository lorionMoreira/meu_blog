using blog_asp_net2.Application.Dtos;
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


        Task<PostDto> AddPosts(PostDto model);
        Task<PostDto> UpdatePost(int eventoId, PostDto model);
        Task<PostDto> GetPostByIdAsync(int postId);

        Task<bool> DeletePost(int PostId);

        Task<PostDto[]> GetAllPostsAsync();

    }
}
