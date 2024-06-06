using CourseStore.Model.Tags.Commands;
using CourseStore.Model.Tags.Queries;
using CourseStore.WebApi.FrameWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseStore.WebApi.Tags
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : BaseController
    {
        public TagsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("CreateTag")]
        public async Task<IActionResult> CreateTag(CreateTag tag)
        {
            if(tag == null)
            {
                return BadRequest("کاربر گرامی مقدار تگ نمی تواند خالی باشد");
            }

            var response = await _mediator.Send(tag);

            return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
        }

        [HttpPut("UpdateTag")]
        public async Task<IActionResult> CreateTag(UpdateTag tag)
        {
            if (tag == null)
            {
                return BadRequest("کاربر گرامی مقدار تگ نمی تواند خالی باشد");
            }

            var response = await _mediator.Send(tag);

            return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
        }

        [HttpGet("FilterbyName")]
        public async Task<IActionResult> FilterByName([FromQuery]FilterByName tag)
        {
            if (tag == null)
            {
                return BadRequest("کاربر گرامی مقدار تگ نمی تواند خالی باشد");
            }

            var response = await _mediator.Send(tag);

            return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
        }
    }
}
