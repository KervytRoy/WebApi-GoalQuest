using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Requests.Goals
{
    public class DeleteGoalRequest : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteGoalRequest(int id)
        {
            Id = id;
        }
    }

    public class DeleteGoalRequestHandler : IRequestHandler<DeleteGoalRequest, int>
    {
        private readonly IRepository<Goal> _goalRepository;

        public DeleteGoalRequestHandler(IRepository<Goal> activityRepository)
        {
            _goalRepository = activityRepository;
        }

        public async Task<int> Handle(DeleteGoalRequest request, CancellationToken cancellationToken)
        {
            var goal = await _goalRepository.GetByIdAsync(request.Id);
            await _goalRepository.DeleteAsync(goal);
            return request.Id;
        }
    }
}