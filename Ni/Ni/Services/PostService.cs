using Ni.Core.Entities;
using Ni.Core.Requests;
using Ni.Core.Responses;
using Ni.Core.Services;
using Ni.Repositories;
using System;
using System.Collections.Generic;

namespace Ni.Services
{
    public class PostService : IPostService
    {
        //private IUserRepository _userRepository;
        private IAuthKeyRepository _authKeyRepository;
        private IPostRepository _postRepository;

        public PostService(IPostRepository postRepository,IUserRepository userRepository, IAuthKeyRepository authKeyRepository)
        {
            _postRepository = postRepository;
            _authKeyRepository = authKeyRepository;
            //_userRepository = userRepository;
        }

        public GenericResponse AddPost(AddPostRequest request)
        {
            GenericResponse response = new GenericResponse();
            response.Errors = new List<string>();
            bool validation = _authKeyRepository.Validate(request.RequesterId, request.AuthKey);
            if (!validation)
            {
                response.StatusCode = 400;
                response.Errors.Add("You do not have access");
            }
            else
            {
                _postRepository.AddPost(request.RequesterId, request.Title, request.Content);
                response.StatusCode = 200;
            }
            return response;
        }

        public GetPostsResponse GetAll(GetAllPostsRequest request)
        {
            GetPostsResponse response = new GetPostsResponse();
            response.StatusCode = 200;
            response.Errors = new List<string>();
            response.Posts = _postRepository.GetAll();
            return response;
        }

        public GetPostsResponse GetLatest(GetLatestPostsRequest request)
        {
            GetPostsResponse response = new GetPostsResponse();
            response.StatusCode = 200;
            response.Errors = new List<string>();
            response.Posts = _postRepository.GetLatest(request.Start,request.Count);
            return response;
        }

        public GetPostResponse GetPostById(GetPostByIdRequest request)
        {
            GetPostResponse response = new GetPostResponse();
            response.StatusCode = 200;
            response.Errors = new List<string>();
            response.Post = _postRepository.GetPostById(request.PostId);
            return response;
        }
    }
}
