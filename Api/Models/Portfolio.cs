using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

[Table("Portfolios")]
public class Portfolio
{
    public string AppUserId { get; set; } = null!;
    public int StockId { get; set; }
    public AppUser AppUser { get; set; } = null!;
    public Stock Stock { get; set; } = null!;
}