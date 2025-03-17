using ControllerTesting.Models;

namespace ControllerTesting.Services.Interfaces;

public interface IBaseballService
{
    Task<List<Team>> GetTeams(int? teamId);

    Task<List<Player>> GetPlayersByTeam(int teamId);
}
