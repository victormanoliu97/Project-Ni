namespace Ni.Core.Requests
{
    public class AddCommentRequest : GenericLoggedInRequest
    {
        public int PostId { get; set; }
        public string Content { get; set; }
    }
}
