using blog_asp_net2.Application.Contratos;
using blog_asp_net2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using blog_asp_net2.Persistence.Contratos;
using Microsoft.Extensions.Logging;

namespace blog_asp_net2.Application
{
    public class PostService : IPostService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IPostPersist _postPersist;

        public PostService(IGeralPersist geralPersist, IPostPersist postPersist)
        {
            _postPersist = postPersist;
            _geralPersist = geralPersist;
        }

        public async Task<Post> AddPosts(Post model)
        {
            try
            {
                _geralPersist.Add<Post>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _postPersist.GetPostByIdAsync(model.id);
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
        
        public async Task<Post> UpdatePost(int postId, Post model)
        {
            try
            {
                var post = await _postPersist.GetPostByIdAsync(postId);
                if (post == null) return null;

                model.id = post.id;

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _postPersist.GetPostByIdAsync(model.id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Post[]> GetAllPostsAsync()
        {
            try
            {
                var posts = await _postPersist.GetAllPostsAsync();
                if (posts == null) return null;

                return posts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Post> GetPostByIdAsync(int postId)
        {
            try
            {
                var posts = await _postPersist.GetPostByIdAsync(postId);
                if (posts == null) return null;

                return posts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
