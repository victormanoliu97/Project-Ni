using System.Collections.Generic;
using Ni.Core.Entities;
using Ni.Repositories;
using System.Linq;

namespace Ni.Infrastructure.Repositories
{
    public class TagRepository : ITagRepository
    {
        private AppDbContext _appDbContext;

        public TagRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddToPost(int postId, string tag)
        {
            Tag newTag = new Tag()
            {
                PostId = postId,
                Title = tag,
            };
            _appDbContext.Tags.Add(newTag);
            _appDbContext.SaveChanges();
        }

        public List<Tag> GetByPostId(int postId)
        {
            var query = from entity in _appDbContext.Tags
                        where entity.PostId == postId
                        select entity;
            return query.ToList();
        }
    }
}