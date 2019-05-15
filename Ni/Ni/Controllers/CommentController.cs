using Microsoft.AspNetCore.Mvc;
using Ni.Core.Requests;
using Ni.Core.Services;

namespace Ni.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [Route("Post")]
        public JsonResult Post(AddCommentRequest request)
        {
            return Json(_commentService.AddComment(request));
        }

        [HttpPost]
        [Route("Sub")]
        public JsonResult PostSub(AddSubCommentRequest request)
        {
            return Json(_commentService.AddSubComment(request));
        }

        [HttpGet]
        [Route("Post")]
        public JsonResult GetByPost([FromQuery] GetCommentsByPostRequest request)
        {
            return Json(_commentService.GetCommentsByPost(request));
        }

        [HttpGet]
        [Route("Sub")]
        public JsonResult GetByComment([FromQuery] GetCommentsByParentCommentRequest request)
        {
            return Json(_commentService.GetCommentsByParentComment(request));
        }
    }
}
