using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IActivityRepository
    {
        Task<IEnumerable<Activity>> GetPaginatedByGoalId(int id, int skip = 0, int take = 10);
        Task<List<Activity>> GetAllActivitiesAsync();
        Task<int> GetTotalActivitiesByGoalId(int goalId);
    }
}
