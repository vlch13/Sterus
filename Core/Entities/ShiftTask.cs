namespace Core.Entities
{
	public class ShiftTask
	{
		public ShiftTask()
		{
		}

		public ShiftTask(string id)
		{
			Id = id;
		}

		public string Id { get; set; }
		public List<TaskItem> Items { get; set; } = new List<TaskItem>();
	}
}