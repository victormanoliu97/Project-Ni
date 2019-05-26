using Ni.Core.Entities;
using Ni.Core.Requests;
using Ni.Core.Responses;
using System.Collections.Generic;

namespace Ni.Core.Services
{
    public interface IPostService
    {
        GenericResponse AddPost(AddPostRequest request);
        GetPostResponse GetPostById(GetPostByIdRequest request);
        GetPostsResponse GetLatest(GetLatestPostsRequest request);
        GetPostsResponse GetAll(GetAllPostsRequest request);
        GetPostsResponse GetAllByCategory(GetAllPostsByCategoryRequest request);

    }
}