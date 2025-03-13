using ControllerTesting.Models;
using ControllerTesting.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControllerTesting.Controllers;

[ApiController]
[Route("baseball")]
public class BaseballController : ControllerBase
{
    private readonly ILogger<BaseballController> _logger;
    private readonly IBaseballService _baseballService;

    public BaseballController(ILogger<BaseballController> logger, IBaseballService baseballService)
    {
        _logger = logger;
        _baseballService = baseballService;
    }

    [HttpGet("teams")]
    public async Task<List<Team>> Get([FromQuery]int? teamId)
    {
        return await _baseballService.GetTeams(teamId);
    }

    [HttpGet("players")]
    public async Task<List<Player>> GetPlayersByTeam([FromQuery]int teamId)
    {
        return await _baseballService.GetPlayersByTeam(teamId);
    }
}
