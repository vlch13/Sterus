namespace Core.Entities
{
	public class Product
	{
		public string Name { get; set; }
		public int BoxLenght { get; set; }
		public int BoxHeight { get; set; }
		public int BoxWidth { get; set; }
		public int BoxWeight { get; set; }
		public int Dose { get; set; }
		public string DoseControl { get; set; }
		public double Speed { get; set; }
		public bool IsMedical { get; set; }
		public ProductCompany ProductCompany { get; set; }
		public int ProductCompanyId { get; set; }
	}
}