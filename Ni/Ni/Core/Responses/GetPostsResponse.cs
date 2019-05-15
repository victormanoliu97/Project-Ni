using System.Collections.Generic;

namespace Ni.Core.Responses
{
    public class GetPostsResponse : GenericResponse
    {
        public List<PostDTO> Posts { get; set; }
    }
}