
using BrandMonitorTest.Models.Entities;

namespace BrandMonitorTest.Services
{
    public interface ITaskService
    {
        Task<TaskEntity> AddTaskAsync();
        Task<TaskEntity>? FindTaskByIdAsync(Guid validGuid);
        Task UpdateTaskAsync(TaskEntity task);
    }
}
