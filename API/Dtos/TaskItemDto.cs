using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
	public class TaskItemDto
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string Company { get; set; }
		[Required]
		public string ProductName { get; set; }
		[Required]
		public double Speed { get; set; }
		[Required]
		public string DoseControl { get; set; }
		[Required]
		public bool IsMedical { get; set; }
		[Required]
		public double Price { get; set; }
		[Required]
		[Range(1, double.MaxValue, ErrorMessage = "Должна быть мининум одна штука")]
		public int Quantity { get; set; }
	}
}