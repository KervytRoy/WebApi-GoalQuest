using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GoalRepository : IGoalRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Goal> _dbSet;

        public GoalRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Goal>();
        }

        public async Task<Goal> GetByIdAsync(int id, int skip = 0, int take = 5)
        {
            return await _dbSet.Include(g => g.Activities)
                                .Where(g => g.Id == id)
                                .Skip(skip)
                                .Take(take)
                                .FirstOrDefaultAsync();
        }
        public async Task<List<Goal>> GetAllGoalsAsync()
        {
            return await _dbSet.Include(g => g.Activities).ToListAsync();
        }
    }
}
