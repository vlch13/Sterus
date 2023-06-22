using System.Text.Json;
using Core.Entities;
using Core.Interfaces;
using StackExchange.Redis;

namespace Infrastructure.Data
{
	public class TaskRepository : ITaskRepository
	{
		private readonly IDatabase _database;
		public TaskRepository(IConnectionMultiplexer redis)
		{
			_database = redis.GetDatabase();
		}

		public async Task<bool> DeleteTaskAsync(string taskId)
		{
			return await _database.KeyDeleteAsync(taskId);
		}

		public async Task<ShiftTask> GetTaskAsync(string taskId)
		{
			var data = await _database.StringGetAsync(taskId);

			return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<ShiftTask>(data);
		}

		public async Task<ShiftTask> UpdateTaskAsync(ShiftTask task)
		{
			var created = await _database.StringSetAsync(task.Id, JsonSerializer.Serialize(task),
			TimeSpan.FromDays(14));

			if (!created) return null;

			return await GetTaskAsync(task.Id);
		}
	}
}