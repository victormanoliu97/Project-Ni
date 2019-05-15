namespace Ni.Core.Requests
{
    public class GetCommentsByParentCommentRequest : GetCommentsByPostRequest
    {
        public int ParentCommentId { get; set; }
    }
}
