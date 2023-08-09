namespace ADO_NET_Solution.Models
{
    public enum OrderStatus
    {
        NotStarted,
        Loading,
        InProgress,
        Arrived,
        Unloading,
        Cancelled,
        Done
    }

    public class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int ProductId { get; set; }
    }
}
