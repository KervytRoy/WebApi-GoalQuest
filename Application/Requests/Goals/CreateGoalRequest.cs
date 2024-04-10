using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Requests.Goals
{
    public class CreateGoalRequest : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public CreateGoalRequest(int id)
        {
            Id = id;
        }
    }

    public class CreateGoalRequestHandler : IRequestHandler<CreateGoalRequest, int>
    {
        private readonly IRepository<Goal> _goalRepository;

        public CreateGoalRequestHandler(IRepository<Goal> goalRepository)
        {
            _goalRepository = goalRepository;
        }

        public async Task<int> Handle(CreateGoalRequest request, CancellationToken cancellationToken)
        {
            var goal = new Goal() { Name = request.Name, CreatedDate = request.CreatedDate };
            await _goalRepository.AddAsync(goal);
            return goal.Id;
        }
    }
}