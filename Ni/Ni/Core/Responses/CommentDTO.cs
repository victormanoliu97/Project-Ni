using Ni.Core.Entities;

namespace Ni.Core.Responses
{
    public class CommentDTO
    {
        public string Username { get; set; }
        public Comment Comment { get; set; }
        public int SubComments { get; set; }
    }
}