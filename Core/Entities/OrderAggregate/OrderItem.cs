namespace Core.Entities.OrderAggregate
{
	public class OrderItem : BaseEntity
	{
		public OrderItem()
		{
		}

		public OrderItem(ProductItemOrdered itemOrdered, int quantity)
		{
			ItemOrdered = itemOrdered;
			Quantity = quantity;
		}

		public ProductItemOrdered ItemOrdered { get; set; }
		public int Quantity { get; set; }
	}
}