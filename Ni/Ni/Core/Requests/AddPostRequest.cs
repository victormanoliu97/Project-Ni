namespace Ni.Core.Requests
{
    public class AddPostRequest : GenericLoggedInRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
