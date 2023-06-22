using Core.Entities;

namespace Core.Interfaces
{
    public interface ITaskRepository
    {
		Task<ShiftTask> GetTaskAsync(string taskId);
		Task<ShiftTask> UpdateTaskAsync(ShiftTask task);
		Task<bool> DeleteTaskAsync(string taskId);
    }
}