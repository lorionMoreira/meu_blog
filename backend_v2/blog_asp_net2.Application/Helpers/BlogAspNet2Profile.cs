using AutoMapper;
using blog_asp_net2.Application.Dtos;
using blog_asp_net2.Domain;
using blog_asp_net2.Domain.Identity;

namespace blog_asp_net2.API.Helpers
{
    public class BlogAspNet2Profile : Profile
    {
        public BlogAspNet2Profile()
        {
            CreateMap<Post, PostDto>().ReverseMap(); 
            CreateMap<Comment, CommentDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }
    }
}
