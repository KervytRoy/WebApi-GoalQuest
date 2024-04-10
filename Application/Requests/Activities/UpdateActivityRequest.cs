using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Requests.Activities
{
    public class UpdateActivityRequest : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UpdateActivityRequest(int id)
        {
            Id = id;
        }
    }

    public class UpdateActivityRequestHandler : IRequestHandler<UpdateActivityRequest, int>
    {
        private readonly IRepository<Activity> _activityRepository;

        public UpdateActivityRequestHandler(IRepository<Activity> activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<int> Handle(UpdateActivityRequest request, CancellationToken cancellationToken)
        {
            var activity = await _activityRepository.GetByIdAsync(request.Id);
            activity.Name = request.Name;
            await _activityRepository.UpdateAsync(activity);
            return activity.Id;
        }
    }
}