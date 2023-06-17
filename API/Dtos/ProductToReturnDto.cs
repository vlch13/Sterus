

namespace API.Dtos
{
	public class ProductToReturnDto
	{
		public int Id { get; set; }
		public string ProductCompany { get; set; }
		public string Name { get; set; }
		public int BoxLenght { get; set; }
		public int BoxHeight { get; set; }
		public int BoxWidth { get; set; } 
		public double BoxWeight { get; set; }
		public int Dose { get; set; }
		public string DoseControl { get; set; }
		public double Speed { get; set; }
		public bool IsMedical { get; set; }
		public decimal Price { get; set; }
		public string Note { get; set; }
	}
}