using Ni.Core.Entities;
using System.Collections.Generic;

namespace Ni.Core.Responses
{
    public class GetPostsResponse : GenericResponse
    {
        public List<Post> Posts { get; set; }
    }
}