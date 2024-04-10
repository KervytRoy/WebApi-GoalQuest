using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Requests.Goals
{
    public class GetGoalByIdRequest : IRequest<GoalDto>
    {
        public int Id { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;

        public GetGoalByIdRequest(int id, int pageNumber = 1, int pageSize = 10)
        {
            Id = id;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetGoalRequestHandler : IRequestHandler<GetGoalByIdRequest, GoalDto>
    {
        private readonly IGoalRepository _repository;

        public GetGoalRequestHandler(IGoalRepository repository)
        {
            _repository = repository;
        }

        public async Task<GoalDto> Handle(GetGoalByIdRequest request, CancellationToken cancellationToken)
        {
            int skip = (request.PageNumber - 1) * request.PageSize;
            var goal = await _repository.GetByIdAsync(request.Id, skip, request.PageSize);

            GoalDto goalDto = new GoalDto()
            {
                Id = goal.Id,
                CreatedDate = goal.CreatedDate,
                Name = goal.Name,
                Activities = goal.Activities.Select(g => new ActivityDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    CreatedDate = g.CreatedDate,
                    Status = g.Status,
                    Important = g.Important
                }).ToList(),
            };

            return goalDto;
        }
    }
}