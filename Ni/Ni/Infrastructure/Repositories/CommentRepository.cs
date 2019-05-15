using System.Collections.Generic;
using Ni.Core.Entities;
using Ni.Repositories;
using System.Linq;
using System;

namespace Ni.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private AppDbContext _appDbContext;

        public CommentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddToComment(int userId, int postId, int parentCommentId, string content)
        {
            Comment newComment = new Comment()
            {
                PostId = postId,
                UserId = userId,
                ParentCommentId = parentCommentId,
                Text = content,
                Date = DateTime.UtcNow,
            };
            _appDbContext.Comments.Add(newComment);
            _appDbContext.SaveChanges();
        }

        public void AddToPost(int userId, int postId, string content)
        {
            Comment newComment = new Comment()
            {
                PostId = postId,
                UserId = userId,
                Text = content,
            };
            _appDbContext.Comments.Add(newComment);
            _appDbContext.SaveChanges();
        }

        public List<Comment> GetByParentCommentId(int postId, int parentCommentId)
        {
            var query = from entity in _appDbContext.Comments
                        where entity.PostId == postId && entity.ParentCommentId == parentCommentId
                        select entity;
            return query.ToList();
        }

        public List<Comment> GetByPostId(int postId)
        {
            var query = from entity in _appDbContext.Comments
                        where entity.PostId == postId && entity.ParentCommentId == 0
                        select entity;
            return query.ToList();
        }
    }
}