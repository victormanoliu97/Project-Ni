using Ni.Core.Entities;
using System.Collections.Generic;

namespace Ni.Core.Responses
{
    public class PostDTO
    {
        public string AuthorUsername { get; set; }
        public Post Post { get; set; }
        public List<string> Tags { get; set; }
    }
}