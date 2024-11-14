using Api.Dtos.Stock;
using Api.Models;

namespace Api.Mappers;

public static class StockMapper
{
    public static StockDto ToStockDto(this Stock stockModel)
    {
        return new StockDto
        {
            Id = stockModel.Id,
            Symbol = stockModel.Symbol,
            CompanyName = stockModel.CompanyName,
            Purchase = stockModel.Purchase,
            LastDiv = stockModel.LastDiv,
            Industry = stockModel.Industry,
            MarketCap = stockModel.MarketCap,
            Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList()
        };
    }

    public static Stock ToStockFromCreateDto(this CreateStockRequestDto stockDto)
    {
        return new Stock
        {
            Symbol = stockDto.Symbol,
            CompanyName = stockDto.CompanyName,
            Purchase = stockDto.Purchase,
            LastDiv = stockDto.LastDiv,
            Industry = stockDto.Industry,
            MarketCap = stockDto.MarketCap
        };
    }

    public static Stock ToStockFromFMPStock(this FMPStock fMPStock)
    {
        return new Stock
        {
            Symbol = fMPStock.Symbol!,
            CompanyName = fMPStock.CompanyName!,
            Purchase = (decimal)fMPStock.Price,
            LastDiv = fMPStock.LastDiv,
            Industry = fMPStock.Industry!,
            MarketCap = fMPStock.MktCap
        };
    }
}