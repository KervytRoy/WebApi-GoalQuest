using Application.Interfaces;
using Application.Requests.Goals;
using Domain.Entities;
using MediatR;

namespace Application.Requests.Activities
{
    public class DeleteActivitiesRequest : IRequest<List<int>>
    {
        public List<int> Ids { get; set; }
        public DeleteActivitiesRequest(List<int> ids)
        {
            Ids = ids;
        }
    }

    public class DeleteActivitiesRequestHandler : IRequestHandler<DeleteActivitiesRequest, List<int>>
    {
        private readonly IRepository<Activity> _activityRepository;

        public DeleteActivitiesRequestHandler(IRepository<Activity> activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<List<int>> Handle(DeleteActivitiesRequest request, CancellationToken cancellationToken)
        {
            var deletedIds = new List<int>();
            foreach (var id in request.Ids)
            {
                var activity = await _activityRepository.GetByIdAsync(id);
                if (activity != null)
                {
                    await _activityRepository.DeleteAsync(activity);
                    deletedIds.Add(id);
                }
            }
            return deletedIds;
        }
    }
}