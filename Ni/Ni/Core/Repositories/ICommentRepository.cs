using Ni.Core.Entities;
using System.Collections.Generic;

namespace Ni.Repositories
{
    public interface ICommentRepository
    {
        List<Comment> GetByPostId(int postId);
        List<Comment> GetByParentCommentId(int postId, int parentCommentId);
        void AddToPost(int userId, int postId, string tag);
        void AddToComment(int userId, int postId, int parentCommentId, string tag);
    }
}