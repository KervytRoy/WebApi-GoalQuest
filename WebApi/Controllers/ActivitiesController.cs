using Application.DTOs;
using Application.Requests.Activities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ActivitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("paginated")]
        public async Task<PaginatedActivitiesDto> GetPaginatedActivities(int goalId, int pageNumber = 1, int pageSize = 10)
        {
            var request = new GetPaginatedActivitiesByGoalId(goalId, pageNumber, pageSize);
            return await _mediator.Send(request);
        }

        [HttpGet("GetAllActivities")]
        public async Task<List<ActivityDto>> GetActivities()
        {
            var request = new GetAllActivitiesRequest();
            return await _mediator.Send(request);
        }

        [HttpPost("CreateActivity")]
        public async Task<IActionResult> CreateActivity(CreateActivityRequest request)
        {
            try
            {
                var activityId = await _mediator.Send(request);
                return Ok(activityId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateActivity/{id}")]
        public async Task<IActionResult> UpdateActivity(int id, UpdateActivityRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            try
            {
                var activityId = await _mediator.Send(request);
                return Ok(activityId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateActivityStatus/{id}")]
        public async Task<IActionResult> UpdateActivityStatus(int id, UpdateActivityStatusRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            try
            {
                var activityId = await _mediator.Send(request);
                return Ok(activityId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateActivityImportantStatus/{id}")]
        public async Task<IActionResult> UpdateActivityImportantStatus(int id, UpdateActivityImportantStatusRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            try
            {
                var activityId = await _mediator.Send(request);
                return Ok(activityId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("DeleteActivities")]
        public async Task<IActionResult> DeleteActivities([FromBody] List<int> ids)
        {
            var request = new DeleteActivitiesRequest(ids);
            try
            {
                var deletedIds = await _mediator.Send(request);
                return Ok(deletedIds);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
