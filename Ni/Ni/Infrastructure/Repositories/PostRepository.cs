using Ni.Core.Entities;
using Ni.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ni.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private AppDbContext _appDbContext;

        public PostRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int AddPost(int userId, int categoryId, string title, string content)
        {
            Post newPost = new Post()
            {
                UserId = userId,
                Title = title,
                Text = content,
                CategoryId = categoryId,
                Date = DateTime.UtcNow,
            };
            _appDbContext.Posts.Add(newPost);
            _appDbContext.SaveChanges();
            return newPost.Id;
        }

        public List<Post> GetAll()
        {
            var query = from entity in _appDbContext.Posts
                        select entity;
            return query.ToList();
        }

        public List<Post> GetByCategory(int categoryId)
        {
            var query = from entity in _appDbContext.Posts
                        where entity.CategoryId == categoryId
                        select entity;
            return query.ToList();
        }

        public List<Post> GetLatest(int start, int count)
        {
            var query = from entity in _appDbContext.Posts
                        orderby entity.Date descending
                        select entity;
            var result = query.Skip(start).ToList();
            return result.GetRange(0, result.Count <= count ? result.Count : count);
        }

        public Post GetPostById(int id)
        {
            var query = from entity in _appDbContext.Posts
                        where entity.Id == id
                        select entity;
            return query.FirstOrDefault();
        }
    }
}