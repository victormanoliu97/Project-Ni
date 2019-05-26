using Microsoft.AspNetCore.Mvc;
using Ni.Core.Requests;
using Ni.Core.Services;

namespace Ni.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public JsonResult Post(AddPostRequest request)
        {
            return Json(_postService.AddPost(request));
        }

        [HttpGet]
        [Route("Id")]
        public JsonResult GetId([FromQuery] GetPostByIdRequest request)
        {
            return Json(_postService.GetPostById(request));
        }

        [HttpGet]
        [Route("Latest")]
        public JsonResult GetLatest([FromQuery] GetLatestPostsRequest request)
        {
            return Json(_postService.GetLatest(request));
        }

        [HttpGet]
        [Route("All")]
        public JsonResult GetAll([FromQuery] GetAllPostsRequest request)
        {
            return Json(_postService.GetAll(request));
        }
        [HttpGet]
        [Route("Category")]
        public JsonResult GetAllByCategory([FromQuery] GetAllPostsByCategoryRequest request)
        {
            return Json(_postService.GetAllByCategory(request));
        }
    }
}
