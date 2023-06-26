namespace Core.Entities.OrderAggregate
{
	public class Order : BaseEntity
	{
		public Order()
		{
		}
		public Order(IReadOnlyList<OrderItem> orderItems, decimal time)
		{
			OrderItems = orderItems;
			Time = time;
		}

		public DateTime OrderDate { get; set; } = DateTime.UtcNow;
		public IReadOnlyList<OrderItem> OrderItems { get; set; }
		public decimal Time { get; set; }


	}
}