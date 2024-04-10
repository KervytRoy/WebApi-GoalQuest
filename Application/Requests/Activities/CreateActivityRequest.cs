using Application.Interfaces;
using Application.Shared.Constants;
using Domain.Entities;
using MediatR;

namespace Application.Requests.Activities
{
    public class CreateActivityRequest : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public int GoalId { get; set; }
        public CreateActivityRequest(int id)
        {
            Id = id;
        }
    }

    public class CreateActivityRequestHandler : IRequestHandler<CreateActivityRequest, int>
    {
        private readonly IRepository<Activity> _activityRepository;

        public CreateActivityRequestHandler(IRepository<Activity> activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<int> Handle(CreateActivityRequest request, CancellationToken cancellationToken)
        {
            var activity = new Activity() { Name = request.Name, CreatedDate = request.CreatedDate, GoalId = request.GoalId, Important = false, Status = ActivityStatusConstants.Open};
            await _activityRepository.AddAsync(activity);
            return activity.Id;
        }
    }
}