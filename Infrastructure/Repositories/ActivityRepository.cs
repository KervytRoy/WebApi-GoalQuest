using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Activity> _dbSet;

        public ActivityRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Activity>();
        }
        public async Task<IEnumerable<Activity>> GetPaginatedByGoalId(int goalId, int pageNumber = 1, int pageSize = 10)
        {
            int skip = (pageNumber - 1) * pageSize;
            return await _dbSet.Where(a => a.GoalId == goalId)
                                .Skip(skip)
                                .Take(pageSize)
                                .ToListAsync();
        }
        public async Task<List<Activity>> GetAllActivitiesAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<int> GetTotalActivitiesByGoalId(int goalId)
        {
            return await _dbSet.CountAsync(a => a.GoalId == goalId);
        }
    }
}
