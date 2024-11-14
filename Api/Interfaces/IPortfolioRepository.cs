using Api.Models;

namespace Api.Interfaces;

public interface IPortfolioRepository
{
    Task<List<Stock>> GetUserPortfolio(AppUser user);
    Task<Portfolio> CreateAsync(Portfolio portfolio);
    Task<Portfolio?> DeletePortfolioAsync(AppUser appUser, string symbol);
}