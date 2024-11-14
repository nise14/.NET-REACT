using System.Net;
using Api.Extensions;
using Api.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PortfolioController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IStockRepository _stockRepository;
    private readonly IPortfolioRepository _portfolioRepository;
    private readonly IFMPService _fmpService;

    public PortfolioController(UserManager<AppUser> userManager,
        IStockRepository stockRepository,
        IPortfolioRepository portfolioRepository,
        IFMPService fMPService)
    {
        _userManager = userManager;
        _stockRepository = stockRepository;
        _portfolioRepository = portfolioRepository;
        _fmpService = fMPService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetUserPortfolio()
    {
        var userName = User.GetUserName();
        var appUser = await _userManager.FindByNameAsync(userName);
        var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser!);
        return Ok(userPortfolio);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddPortfolio(string symbol)
    {
        var userName = User.GetUserName();
        var appUser = await _userManager.FindByNameAsync(userName);
        var stock = await _stockRepository.GetBySymbolAsync(symbol);

        if (stock == null)
        {
            stock = await _fmpService.FindStockBySymbolAsync(symbol);

            if (stock == null)
            {
                return BadRequest("Stock does not exists");
            }
            else
            {
                await _stockRepository.CreateAsync(stock);
            }
        }

        var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser!);

        if (userPortfolio.Any(e => e.Symbol.Equals(symbol, StringComparison.CurrentCultureIgnoreCase)))
        {
            return BadRequest("Cannot add same stock to portfolio");
        }

        var portfolioModel = new Portfolio
        {
            StockId = stock.Id,
            AppUserId = appUser!.Id
        };

        await _portfolioRepository.CreateAsync(portfolioModel);

        if (portfolioModel == null)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, "Could not create");
        }
        else
        {
            return Created();
        }
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeletePortfolio(string symbol)
    {
        var userName = User.GetUserName();
        var appUser = await _userManager.FindByNameAsync(userName);

        var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser!);

        var filteredStock = userPortfolio.Where(s => s.Symbol.Equals(symbol, StringComparison.CurrentCultureIgnoreCase)).ToList();

        if (filteredStock.Count == 1)
        {
            await _portfolioRepository.DeletePortfolioAsync(appUser!, symbol);
        }
        else
        {
            return BadRequest("Stock not in your portfolio");
        }

        return Ok();
    }
}