using Ni.Core.Entities;
using System.Collections.Generic;

namespace Ni.Repositories
{
    public interface IPostRepository
    {
        int AddPost(int userId, int categoryId, string title, string content);
        Post GetPostById(int id);
        List<Post> GetLatest(int start, int count);
        List<Post> GetAll();
        List<Post> GetByCategory(int categoryId);
    }
    public interface ICategoryRepository
    {
        Category GetCategoryByUrl(string url);
    }
}