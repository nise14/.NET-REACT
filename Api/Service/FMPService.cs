using System.Text.Json;
using Api.Dtos.Stock;
using Api.Interfaces;
using Api.Mappers;
using Api.Models;

namespace Api.Service;

public class FMPService : IFMPService
{
    private readonly HttpClient _client;
    private readonly IConfiguration _config;

    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public FMPService(HttpClient client, IConfiguration config)
    {
        _client = client;
        _config = config;
        _jsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<Stock> FindStockBySymbolAsync(string symbol)
    {
        try
        {
            var result = await _client.GetAsync($"https://financialmodelingprep.com/api/v3/profile/{symbol}?apikey={_config["FMPKey"]}");

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                var tasks = JsonSerializer.Deserialize<FMPStock[]>(content, _jsonSerializerOptions)!;

                var stock = tasks[0];
                if (stock is not null)
                {
                    return stock.ToStockFromFMPStock();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        return null!;
    }
}