using Application.DTOs;
using Application.Interfaces;
using MediatR;

namespace Application.Requests.Activities
{
    public class GetAllActivitiesRequest : IRequest<List<ActivityDto>>
    {
        public int Id { get; set; }
    }

    public class GetAllActivitiesRequestHandler : IRequestHandler<GetAllActivitiesRequest, List<ActivityDto>>
    {
        private readonly IActivityRepository _repository;

        public GetAllActivitiesRequestHandler(IActivityRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ActivityDto>> Handle(GetAllActivitiesRequest request, CancellationToken cancellationToken)
        {
            var activities = await _repository.GetAllActivitiesAsync();
            var activitiesDto = activities.Select(g => new ActivityDto
            {
                Id = g.Id,
                Name = g.Name
            });
            return activitiesDto.ToList();
        }

    }
}
