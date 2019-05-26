using Ni.Core.Entities;
using Ni.Repositories;
using System.Linq;

namespace Ni.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Category GetCategoryByUrl(string url)
        {
            var query = from entity in _appDbContext.Categories
                        where entity.URL == url
                        select entity;
            return query.FirstOrDefault();
        }
    }
}