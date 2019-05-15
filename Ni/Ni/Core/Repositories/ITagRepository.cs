using Ni.Core.Entities;
using System.Collections.Generic;

namespace Ni.Repositories
{
    public interface ITagRepository
    {
        List<Tag> GetByPostId(int postId);
        void AddToPost(int postId, string tag);
    }
}