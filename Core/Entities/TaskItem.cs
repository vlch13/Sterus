namespace Core.Entities
{
	public class TaskItem
	{
		public int Id { get; set; }
		public string Company { get; set; }
		public string ProductName { get; set; }
		public double Speed { get; set; }
		public string DoseControl { get; set; }
		public bool IsMedical { get; set; }
		public double Price { get; set; }
		public int Quantity { get; set; }
	}
}