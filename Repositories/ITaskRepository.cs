using BrandMonitorTest.Models.Entities;

namespace BrandMonitorTest.Repositories
{
    public interface ITaskRepository
    {
        Task AddTaskAsync(TaskEntity task);
        Task<TaskEntity>? FindTaskByIdAsync(Guid validGuid);
        Task SaveTaskStatusAsync();
    }
}
