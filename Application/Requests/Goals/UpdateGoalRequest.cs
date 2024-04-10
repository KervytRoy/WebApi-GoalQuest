using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Requests.Goals
{
    public class UpdateGoalRequest : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UpdateGoalRequest(int id)
        {
            Id = id;
        }
    }

    public class UpdateGoalRequestHandler : IRequestHandler<UpdateGoalRequest, int>
    {
        private readonly IRepository<Goal> _goalRepository;

        public UpdateGoalRequestHandler(IRepository<Goal> activityRepository)
        {
            _goalRepository = activityRepository;
        }

        public async Task<int> Handle(UpdateGoalRequest request, CancellationToken cancellationToken)
        {
            var goal = await _goalRepository.GetByIdAsync(request.Id);
            goal.Name = request.Name;
            await _goalRepository.UpdateAsync(goal);
            return goal.Id;
        }
    }
}