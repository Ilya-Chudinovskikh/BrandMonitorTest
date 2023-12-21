using BrandMonitorTest.Data;
using BrandMonitorTest.Models.Entities;
using BrandMonitorTest.Models.Enums;
using System.Threading.Tasks;

namespace BrandMonitorTest.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly BrandMonitorTestContext _context;

        public TaskRepository(BrandMonitorTestContext context)
        {
            _context = context;
        }

        public async Task AddTaskAsync(TaskEntity task)
        {
            _context.TaskEntity.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task<TaskEntity>? FindTaskByIdAsync(Guid validGuid)
        {
            return await _context.TaskEntity.FindAsync(validGuid);
        }

        public async Task SaveTaskStatusAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
