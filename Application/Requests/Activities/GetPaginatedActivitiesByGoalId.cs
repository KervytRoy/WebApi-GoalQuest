using Application.DTOs;
using Application.Interfaces;
using Application.Requests.Goals;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Activities
{
    public class GetPaginatedActivitiesByGoalId : IRequest<PaginatedActivitiesDto>
    {
        public int GoalId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;

        public GetPaginatedActivitiesByGoalId(int goalId, int pageNumber = 1, int pageSize = 10)
        {
            GoalId = goalId;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetPaginatedActivitiesByGoalIdHandler : IRequestHandler<GetPaginatedActivitiesByGoalId, PaginatedActivitiesDto>
    {
        private readonly IActivityRepository _repository;

        public GetPaginatedActivitiesByGoalIdHandler(IActivityRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedActivitiesDto> Handle(GetPaginatedActivitiesByGoalId request, CancellationToken cancellationToken)
        {
            var activities = await _repository.GetPaginatedByGoalId(request.GoalId, request.PageNumber, request.PageSize);
            var totalActivities = await _repository.GetTotalActivitiesByGoalId(request.GoalId);
            var activitiesDto = activities.Select(a => new ActivityDto
            {
                Id = a.Id,
                Name = a.Name,
                CreatedDate = a.CreatedDate,
                Status = a.Status,
                Important = a.Important
            });

            return new PaginatedActivitiesDto
            {
                TotalRecords = totalActivities,
                Activities = activitiesDto.ToList()
            };
        }
    }
    public class PaginatedActivitiesDto
    {
        public int TotalRecords { get; set; }
        public List<ActivityDto> Activities { get; set; }
    }
}