using System.Collections.Generic;

namespace Ni.Core.Requests
{
    public class AddPostRequest : GenericLoggedInRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }
        public string Image { get; set; }
    }
}
