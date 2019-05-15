using System.Collections.Generic;

namespace Ni.Core.Responses
{
    public class GetCommentsResponse : GenericResponse
    {
        public List<CommentDTO> Comments { get; set; }
    }
}