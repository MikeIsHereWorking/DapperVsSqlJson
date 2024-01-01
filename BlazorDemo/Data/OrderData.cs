using BlazorDemo.Models;
using System.Diagnostics;
using System.Text.Json;

namespace BlazorDemo.Data;

public class OrderData
{
    private readonly SqlDataAccess _sql;

    public OrderData(SqlDataAccess sql)
    {
        _sql = sql;
    }




    public async Task<List<OrderModel>> GetOrdersAsyncJson()
    {
        string jsonResponse = await _sql.LoadDataAsyncNonList("dbo.spOrders_GetAll_Json",
            new { });

        return JsonSerializer.Deserialize<List<OrderModel>>(jsonResponse) ?? new List<OrderModel>();
    }

    public async Task<long> GetIterationsOf_GetOrdersAsyncJson(int iterations) {

        Stopwatch sw = new Stopwatch();
        sw.Start();

        for (int i = 0; i < iterations; i++)
        {
            await GetOrdersAsyncJson();
        }
        sw.Stop();
        return sw.ElapsedMilliseconds;
    }


    public async Task<long> GetIterationsOf_GetOrdersAsync(int iterations)
    {

        Stopwatch sw = new Stopwatch();
        sw.Start();

        for (int i = 0; i < iterations; i++)
        {
            await GetOrdersAsync();
        }
        sw.Stop();
        return sw.ElapsedMilliseconds;
    }

    public async Task<List<OrderModel>> GetOrdersAsync()
    {
        var orders = await _sql.LoadDataAsync<OrderModel, dynamic>(
            "dbo.spOrders_GetAll",
            new { });

        List<OrderDetailModel> details = await _sql.LoadDataAsync<OrderDetailModel, dynamic>(
            "dbo.spOrderDetails_GetAll",
            new { });

        foreach (var order in orders)
        {
            order.LineItems = details.Where(x => x.OrderId == order.Id).ToList();
        }

        return orders;
    }

    public async Task<OrderModel?> GetOrderAsync(int id)
    {
        var orders = await _sql.LoadDataAsync<OrderModel, dynamic>(
            "dbo.spOrders_GetById",
            new { Id = id });

        OrderModel? order = orders.FirstOrDefault();

        if (order is null)
        {
            return null;
        }

        List<OrderDetailModel> details = await _sql.LoadDataAsync<OrderDetailModel, dynamic>(
            "dbo.spOrderDetails_GetByOrderId",
            new { OrderId = id });

        order.LineItems = details;

        return order;
    }

    public async Task<List<OrderModel>> GetOrdersByDateAsync(
        DateTime startDate,
        DateTime endDate)
    {
        var orders = await _sql.LoadDataAsync<OrderModel, dynamic>(
            "dbo.spOrders_GetByDate",
            new { StartDate = startDate, EndDate = endDate });

        List<OrderDetailModel> details = await _sql.LoadDataAsync<OrderDetailModel, dynamic>(
            "dbo.spOrderDetails_GetByDate",
            new { StartDate = startDate, EndDate = endDate });

        foreach (var order in orders)
        {
            order.LineItems = details.Where(x => x.OrderId == order.Id).ToList();
        }

        return orders;
    }

}
