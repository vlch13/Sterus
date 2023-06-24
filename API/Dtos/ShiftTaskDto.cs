using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
	public class ShiftTaskDto
	{
		[Required]
		public string Id { get; set; }
		public List<TaskItemDto> Items { get; set; }
	}
}