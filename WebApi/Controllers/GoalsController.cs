using Application.DTOs;
using Application.Requests.Goals;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GoalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetGoal/{id}")]
        public async Task<GoalDto> GetGoal(int id)
        {
            var request = new GetGoalByIdRequest(id);
            return await _mediator.Send(request);
        }

        [HttpGet("GetAllGoals")]
        public async Task<List<GoalDto>> GetGoals()
        {
            var request = new GetGoalsRequest();
            return await _mediator.Send(request);
        }

        [HttpPost("CreateGoal")]
        public async Task<IActionResult> CreateGoal(CreateGoalRequest request)
        {
            try
            {
                var goalId = await _mediator.Send(request);
                return Ok(goalId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateGoal/{id}")]
        public async Task<IActionResult> UpdateGoal(int id, UpdateGoalRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            try
            {
                var goalId = await _mediator.Send(request);
                return Ok(goalId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteGoal/{id}")]
        public async Task<IActionResult> DeleteGoal(int id)
        {
            var request = new DeleteGoalRequest(id);
            try
            {
                var goalId = await _mediator.Send(request);
                return Ok(goalId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}
