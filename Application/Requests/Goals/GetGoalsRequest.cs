using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Requests.Goals
{
    public class GetGoalsRequest : IRequest<List<GoalDto>>
    {
        public int Id { get; set; }
    }

    public class GetGoalsRequestHandler : IRequestHandler<GetGoalsRequest, List<GoalDto>>
    {
        private readonly IGoalRepository _repository;

        public GetGoalsRequestHandler(IGoalRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GoalDto>> Handle(GetGoalsRequest request, CancellationToken cancellationToken)
        {
            var goals = await _repository.GetAllGoalsAsync();
            var goalsDto = goals.Select(g => new GoalDto
            {
                Id = g.Id,
                Name = g.Name,
                CreatedDate = g.CreatedDate,
                Activities = g.Activities.Select(a => new ActivityDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Status = a.Status,
                    CreatedDate = a.CreatedDate,
                    Important = a.Important,
                    GoalId = a.GoalId
                }).ToList()
            });
            return goalsDto.ToList();
        }

    }
}