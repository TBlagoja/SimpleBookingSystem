using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BugController : BaseApiController
    {
        private readonly ApplicationContext _context;

        public BugController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var recource = _context.Resources.Find(42);

            if (recource == null)
            {
                return NotFound(new ApiResponse(404));
            } 

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var resource = _context.Resources.Find(42);

            var recourceToReturn = resource.ToString();

            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }

    }
}
