using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Requests.Activities
{
    public class UpdateActivityImportantStatusRequest : IRequest<int>
    {
        public int Id { get; set; }
        public bool ImportantStatus { get; set; }
        public UpdateActivityImportantStatusRequest(int id)
        {
            Id = id;
        }
    }

    public class UpdateActivityImportantStatusRequestHandler : IRequestHandler<UpdateActivityImportantStatusRequest, int>
    {
        private readonly IRepository<Activity> _activityRepository;

        public UpdateActivityImportantStatusRequestHandler(IRepository<Activity> activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<int> Handle(UpdateActivityImportantStatusRequest request, CancellationToken cancellationToken)
        {
            var activity = await _activityRepository.GetByIdAsync(request.Id);
            activity.Important = request.ImportantStatus;
            await _activityRepository.UpdateAsync(activity);
            return activity.Id;
        }
    }
}
