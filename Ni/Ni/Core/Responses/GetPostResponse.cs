using Ni.Core.Entities;

namespace Ni.Core.Responses
{
    public class GetPostResponse : GenericResponse
    {
        public Post Post { get; set; }
    }
}