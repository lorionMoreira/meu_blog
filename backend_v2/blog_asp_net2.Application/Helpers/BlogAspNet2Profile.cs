using AutoMapper;
using blog_asp_net2.Application.Dtos;
using blog_asp_net2.Domain;

namespace blog_asp_net2.API.Helpers
{
    public class BlogAspNet2Profile : Profile
    {
        public BlogAspNet2Profile()
        {
            CreateMap<Post, PostDto>().ReverseMap(); 
            CreateMap<Comment, CommentDto>().ReverseMap();
        }
    }
}
