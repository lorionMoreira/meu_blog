using blog_asp_net2.Application.Contratos;
using blog_asp_net2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using blog_asp_net2.Persistence.Contratos;
using Microsoft.Extensions.Logging;
using AutoMapper;
using blog_asp_net2.Application.Dtos;

namespace blog_asp_net2.Application
{
    public class PostService : IPostService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IPostPersist _postPersist;
        private readonly IMapper _mapper;
        public PostService(IGeralPersist geralPersist, IPostPersist postPersist, IMapper mapper)
        {
            _postPersist = postPersist;
            _geralPersist = geralPersist;
            _mapper = mapper;
        }

        public async Task<PostDto> AddPosts(PostDto model)
        {
            try
            {
                var post = _mapper.Map<Post>(model);

                _geralPersist.Add<Post>(post);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var eventoRetorno = await _postPersist.GetPostByIdAsync(post.id);

                    return _mapper.Map<PostDto>(eventoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePost(int postId)
        {
            try
            {
                var post = await _postPersist.GetPostByIdAsync(postId);
                if (post == null) throw new Exception("post para delete não encontrado.");

                _geralPersist.Delete<Post>(post);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<PostDto> UpdatePost(int postId, PostDto model)
        {
            try
            {
                var post = await _postPersist.GetPostByIdAsync(postId);
                if (post == null) return null;

                model.id = post.id;

                _mapper.Map(model, post);

                _geralPersist.Update<Post>(post);

                if (await _geralPersist.SaveChangesAsync())
                {

                    var postRetorno = await _postPersist.GetPostByIdAsync(post.id);
                    return _mapper.Map<PostDto>(postRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PostDto[]> GetAllPostsAsync()
        {
            try
            {
                var posts = await _postPersist.GetAllPostsAsync();


                if (posts == null) return null;

                var resultado = _mapper.Map<PostDto[]>(posts);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PostDto> GetPostByIdAsync(int postId)
        {
            try
            {
                var posts = await _postPersist.GetPostByIdAsync(postId);
                if (posts == null) return null;

                var resultado = _mapper.Map<PostDto>(posts);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
