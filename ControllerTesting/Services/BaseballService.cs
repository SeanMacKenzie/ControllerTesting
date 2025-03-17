using ControllerTesting.Models;
using ControllerTesting.Services.Interfaces;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ControllerTesting.Services;

public class BaseballService : IBaseballService
{
    private readonly HttpClient _httpClient;
    private readonly string _key = "741be366-a582-4e1d-8c27-28071f6dd5e4";
    private readonly string _baseUrl = "https://api.balldontlie.io/mlb/v1/";

    public BaseballService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Add("Authorization", _key);
    }

    public async Task<List<Team>> GetTeams(int? teamId)
    {
        try
        {
            string url = teamId.HasValue ? $"{_baseUrl}teams/{teamId}" : $"{_baseUrl}teams";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                if (teamId.HasValue)
                {
                    var singleTeamResponse = JsonSerializer.Deserialize<SingleTeamResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    var team = new Team
                    {
                        ApiId = singleTeamResponse.Data.Id,
                        Slug = singleTeamResponse.Data.Slug,
                        Abbreviation = singleTeamResponse.Data.Abbreviation,
                        Name = singleTeamResponse.Data.Name,
                        DisplayName = singleTeamResponse.Data.DisplayName,
                        ShortDisplayName = singleTeamResponse.Data.ShortDisplayName,
                        League = singleTeamResponse.Data.League,
                        Division = singleTeamResponse.Data.Division,
                        Location = singleTeamResponse.Data.Location,
                    };

                    return new List<Team> { team };
                }
                else
                {
                    var teamsResponse = JsonSerializer.Deserialize<TeamsResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    // Map API response to your Team model list
                    var teams = teamsResponse.Data.Select(apiTeam => new Team
                    {
                        ApiId = apiTeam.Id,
                        Abbreviation = apiTeam.Abbreviation,
                        Slug = apiTeam.Slug,
                        Location = apiTeam.Location,
                        Name = apiTeam.Name,
                        DisplayName = apiTeam.DisplayName,
                        ShortDisplayName = apiTeam.ShortDisplayName,
                        League = apiTeam.League,
                        Division = apiTeam.Division
                    }).ToList();

                    return teams;
                }
            }

            return new List<Team>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching teams from Balldontlie: {ex.Message}");
            return new List<Team>();
        }
    }

    public async Task<List<Player>> GetPlayersByTeam(int teamId)
    {
        try
        {
            var url = $"{_baseUrl}players?team_ids[]={teamId}&per_page=100";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                var playersResponse = JsonSerializer.Deserialize<PlayersResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var players = playersResponse.Data.Select(apiPlayer => new Player
                {
                    ApiId = apiPlayer.Id,
                    FirstName = apiPlayer.FirstName,
                    LastName = apiPlayer.LastName,
                    FullName = apiPlayer.FullName,
                    DebutYear = apiPlayer.DebutYear,
                    Jersey = apiPlayer.Jersey,
                    College = apiPlayer.College,
                    Position = apiPlayer.Position,
                    IsActive = apiPlayer.Active,
                    BirthPlace = apiPlayer.BirthPlace,
                    DateOfBirth = apiPlayer.Dob,
                    Age = apiPlayer.Age,
                    Height = apiPlayer.Height,
                    Weight = apiPlayer.Weight,
                    Draft = apiPlayer.Draft,
                    BatThrows = apiPlayer.BatThrows,
                    Team = new Team
                    {
                        ApiId = apiPlayer.Team.Id,
                        Abbreviation = apiPlayer.Team.Abbreviation,
                        Slug = apiPlayer.Team.Slug,
                        Location = apiPlayer.Team.Location,
                        Name = apiPlayer.Team.Name,
                        DisplayName = apiPlayer.Team.DisplayName,
                        ShortDisplayName = apiPlayer.Team.ShortDisplayName,
                        League = apiPlayer.Team.League,
                        Division = apiPlayer.Team.Division
                    },
                }).ToList();

                return players;
            }

            return new List<Player>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching players from Balldontlie: {ex.Message}");
            return new List<Player>();
        }
    }
}
