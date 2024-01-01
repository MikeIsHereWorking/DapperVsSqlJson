namespace BlazorDemo.Models;

public class OrderDetailModel
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string? Item { get; set; }
    public decimal Price { get; set; }
}
