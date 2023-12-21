using BrandMonitorTest.Data;
using BrandMonitorTest.Models.Entities;
using BrandMonitorTest.Models.Enums;
using BrandMonitorTest.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BrandMonitorTest.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TaskEntity> AddTaskAsync()
        {
            var task = new TaskEntity();

            await _repository.AddTaskAsync(task);

            return task;
        }

        public async Task<TaskEntity>? FindTaskByIdAsync(Guid validGuid)
        {
            return await _repository.FindTaskByIdAsync(validGuid);
        }

        public async Task UpdateTaskAsync(TaskEntity task)
        {
            await UpdateTaskStatusAsync(task);

            await Task.Delay(TimeSpan.FromMinutes(2));

            await UpdateTaskStatusAsync(task);
        }

        private async Task UpdateTaskStatusAsync(TaskEntity task)
        {
            if (task.Status == TaskStatusType.Created)
                task.Status = TaskStatusType.Running;
            else
                task.Status = TaskStatusType.Finished;

            task.Time = TimeOnly.FromDateTime(DateTime.Now);

            await _repository.SaveTaskStatusAsync();
        }
    }
}
