using Ni.Core.Entities;
using System.Collections.Generic;

namespace Ni.Repositories
{
    public interface IPostRepository
    {
        void AddPost(Post post);
        Post GetPostById(int id);
        List<Post> GetLatest(int count);
        List<Post> GetAll();
    }
}