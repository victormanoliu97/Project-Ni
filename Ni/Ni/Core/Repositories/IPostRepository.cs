using Ni.Core.Entities;
using System.Collections.Generic;

namespace Ni.Repositories
{
    public interface IPostRepository
    {
        int AddPost(int userId, string title, string content);
        Post GetPostById(int id);
        List<Post> GetLatest(int start, int count);
        List<Post> GetAll();
    }
}