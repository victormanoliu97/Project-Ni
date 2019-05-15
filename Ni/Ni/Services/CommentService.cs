using Ni.Core.Requests;
using Ni.Core.Responses;
using Ni.Core.Services;
using Ni.Repositories;
using System;
using System.Collections.Generic;

namespace Ni.Services
{
    public class CommentService : ICommentService
    {
        private IAuthKeyRepository _authKeyRepository;
        private IPostRepository _postRepository;
        private ICommentRepository _commentRepository;
        private IUserRepository _userRepository;
        public CommentService(IPostRepository postRepository, IAuthKeyRepository authKeyRepository,
            ICommentRepository commentRepository, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _authKeyRepository = authKeyRepository;
            _commentRepository = commentRepository;
        }

        public GenericResponse AddComment(AddCommentRequest request)
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
                _commentRepository.AddToPost(request.RequesterId, request.PostId, request.Content);
                response.StatusCode = 200;
            }
            return response;
        }

        public GenericResponse AddSubComment(AddSubCommentRequest request)
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
                _commentRepository.AddToComment(request.RequesterId, request.PostId, request.ParentCommentId, request.Content);
                response.StatusCode = 200;
            }
            return response;
        }

        public GetCommentsResponse GetCommentsByParentComment(GetCommentsByParentCommentRequest request)
        {
            GetCommentsResponse response = new GetCommentsResponse();
            response.StatusCode = 200;
            response.Errors = new List<string>();
            var comments = _commentRepository.GetByParentCommentId(request.PostId, request.ParentCommentId);
            List<CommentDTO> dtos = new List<CommentDTO>();
            foreach (var comment in comments)
            {
                CommentDTO dto = new CommentDTO()
                {
                    Comment = comment,
                    Username = _userRepository.GetUserById(comment.UserId).Username,
                    SubComments = _commentRepository.GetByParentCommentId(comment.PostId, comment.Id).Count,
                };
                dtos.Add(dto);
            }
            response.Comments = dtos;
            return response;
        }

        public GetCommentsResponse GetCommentsByPost(GetCommentsByPostRequest request)
        {
            GetCommentsResponse response = new GetCommentsResponse();
            response.StatusCode = 200;
            response.Errors = new List<string>();
            var comments = _commentRepository.GetByPostId(request.PostId);
            List<CommentDTO> dtos = new List<CommentDTO>();
            foreach (var comment in comments)
            {
                CommentDTO dto = new CommentDTO()
                {
                    Comment = comment,
                    Username = _userRepository.GetUserById(comment.UserId).Username,
                    SubComments = _commentRepository.GetByParentCommentId(comment.PostId, comment.Id).Count,
                };
                dtos.Add(dto);
            }
            response.Comments = dtos;
            return response;
        }
    }
}
