namespace Core.Entities
{
	public class Product : BaseEntity
	{
		public string Name { get; set; }
		public int BoxLenght { get; set; } = 100;
		public int BoxHeight { get; set; } = 100;
		public int BoxWidth { get; set; } = 100;
		public double BoxWeight { get; set; } = 5;
		public int Dose { get; set; }
		public string DoseControl { get; set; }
		public double Speed { get; set; }
		public bool IsMedical { get; set; }
		public decimal Price { get; set; } = 100;
		public string Note { get; set; } = null;
		public ProductCompany ProductCompany { get; set; }
		public int ProductCompanyId { get; set; }
	}
}