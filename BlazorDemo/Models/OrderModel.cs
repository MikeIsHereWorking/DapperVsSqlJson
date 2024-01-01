namespace BlazorDemo.Models;

public class OrderModel
{
    public int Id { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal Total { get; set; }
    public List<OrderDetailModel> LineItems { get; set; } = new();
}
