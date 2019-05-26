using Ni.Core.Requests;
using Ni.Core.Responses;

namespace Ni.Core.Services
{
    public interface ICommentService
    {
        GenericResponse AddComment(AddCommentRequest request);
        GenericResponse AddSubComment(AddSubCommentRequest request);
        GetCommentsResponse GetCommentsByPost(GetCommentsByPostRequest request);
        GetCommentsResponse GetCommentsByParentComment(GetCommentsByParentCommentRequest request);
    }
}