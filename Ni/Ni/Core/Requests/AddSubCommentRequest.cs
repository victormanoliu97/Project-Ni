namespace Ni.Core.Requests
{
    public class AddSubCommentRequest : AddCommentRequest
    {
        public int ParentCommentId { get; set; }
    }
}
