using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Ni.Core.Entities;
using Ni.Core.Requests;
using Ni.Core.Responses;
using Ni.Core.Services;
using Ni.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ni.Services
{
    public class PostService : IPostService
    {
        private IAuthKeyRepository _authKeyRepository;
        private IPostRepository _postRepository;
        private ITagRepository _tagRepository;
        private IUserRepository _userRepository;
        private ICategoryRepository _categoryRepository;

        public PostService(IPostRepository postRepository, IAuthKeyRepository authKeyRepository,
            ITagRepository tagRepository, IUserRepository userRepository, ICategoryRepository categoryRepository)
        {
            _postRepository = postRepository;
            _authKeyRepository = authKeyRepository;
            _tagRepository = tagRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
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
                int postId = _postRepository.AddPost(request.RequesterId, request.Title, request.Content);
                foreach (var tag in request.Tags)
                {
                    _tagRepository.AddToPost(postId, tag);
                }
                response.StatusCode = 200;
                string connString = "DefaultEndpointsProtocol=https;AccountName=timefunctionnip8ca1;AccountKey=yexSIebMMLZTojXbWS6QSvSOEoxXIqQW3l9oNjfpjdwVRrQKYgMQj1cgrrU7aHnVygp+TQPRsGoeq1UkWaxkUw==;EndpointSuffix=core.windows.net";
                CloudStorageAccount.TryParse(connString, out var storageAccount);
                var cloudBlobClient = storageAccount.CreateCloudBlobClient();
                var container = cloudBlobClient.GetContainerReference("files");
                var cloudBlockBlob = container.GetBlockBlobReference(postId + ".png");
                byte[] imageBytes = Convert.FromBase64String(request.Image);
                cloudBlockBlob.UploadFromByteArray(imageBytes, 0, imageBytes.Length);
            }
            return response;
        }

        public GetPostsResponse GetAll(GetAllPostsRequest request)
        {
            GetPostsResponse response = new GetPostsResponse();
            response.StatusCode = 200;
            response.Errors = new List<string>();
            response.Posts = new List<PostDTO>();
            var posts = _postRepository.GetAll();
            foreach (var post in posts)
            {
                var tags = new List<string>();
                var tagEntities = _tagRepository.GetByPostId(post.Id);
                foreach (var tag in tagEntities)
                {
                    tags.Add(tag.Content);
                }
                PostDTO postWithTags = new PostDTO()
                {
                    Post = post,
                    Tags = tags,
                    AuthorUsername = _userRepository.GetUserById(post.UserId).Username,
                };
                response.Posts.Add(postWithTags);
            }
            return response;
        }

        public GetPostsResponse GetAllByCategory(GetAllPostsByCategoryRequest request)
        {
            GetPostsResponse response = new GetPostsResponse();
            response.StatusCode = 200;
            response.Errors = new List<string>();
            response.Posts = new List<PostDTO>();
            var cat = _categoryRepository.GetCategoryByUrl(request.CategoryURL);
            if(cat == null)
            {
                response.StatusCode = 404;
                response.Errors.Add("Category not found");
                return response;
            }
            var posts = _postRepository.GetByCategory(cat.Id);
            foreach (var post in posts)
            {
                var tags = new List<string>();
                var tagEntities = _tagRepository.GetByPostId(post.Id);
                foreach (var tag in tagEntities)
                {
                    tags.Add(tag.Content);
                }
                PostDTO postWithTags = new PostDTO()
                {
                    Post = post,
                    Tags = tags,
                    AuthorUsername = _userRepository.GetUserById(post.UserId).Username,
                };
                response.Posts.Add(postWithTags);
            }
            return response;
        }

        public GetPostsResponse GetLatest(GetLatestPostsRequest request)
        {
            GetPostsResponse response = new GetPostsResponse();
            response.StatusCode = 200;
            response.Errors = new List<string>();
            response.Posts = new List<PostDTO>();
            var posts = _postRepository.GetLatest(request.Start,request.Count);
            foreach (var post in posts)
            {
                var tags = new List<string>();
                var tagEntities = _tagRepository.GetByPostId(post.Id);
                foreach (var tag in tagEntities)
                {
                    tags.Add(tag.Content);
                }
                PostDTO postWithTags = new PostDTO()
                {
                    Post = post,
                    Tags = tags,
                    AuthorUsername = _userRepository.GetUserById(post.UserId).Username,
                };
                response.Posts.Add(postWithTags);
            }
            return response;
        }

        public GetPostResponse GetPostById(GetPostByIdRequest request)
        {
            GetPostResponse response = new GetPostResponse();
            response.StatusCode = 200;
            response.Errors = new List<string>();
            var tags = new List<string>();
            var tagEntities = _tagRepository.GetByPostId(request.PostId);
            foreach (var tag in tagEntities)
            {
                tags.Add(tag.Content);
            }
            var post = _postRepository.GetPostById(request.PostId);
            response.Post = new PostDTO()
            {
                Post = post,
                Tags = tags,
                AuthorUsername = _userRepository.GetUserById(post.UserId).Username,
            };
            return response;
        }
    }
}
