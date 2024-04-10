using Application.Interfaces;
using Application.Shared.Constants;
using Domain.Entities;
using MediatR;

namespace Application.Requests.Activities
{
    public class UpdateActivityStatusRequest : IRequest<int>
    {
        public int Id { get; set; }
        public UpdateActivityStatusRequest(int id)
        {
            Id = id;
        }
    }

    public class UpdateActivityStatusRequestHandler : IRequestHandler<UpdateActivityStatusRequest, int>
    {
        private readonly IRepository<Activity> _activityRepository;

        public UpdateActivityStatusRequestHandler(IRepository<Activity> activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<int> Handle(UpdateActivityStatusRequest request, CancellationToken cancellationToken)
        {
            var activity = await _activityRepository.GetByIdAsync(request.Id);
            activity.Status = ActivityStatusConstants.Completed;
            await _activityRepository.UpdateAsync(activity);
            return activity.Id;
        }
    }
}