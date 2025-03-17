using System.Text.Json.Serialization;

namespace ControllerTesting.Models;

public class Team
{
    public int ApiId { get; set; }
    public string? Slug { get; set; }
    public string? Abbreviation { get; set; }
    public string? DisplayName { get; set; }
    public string? ShortDisplayName { get; set; }
    public string? Name { get; set; }
    public string? League { get; set; }
    public string? Division { get; set; }
    public string? Location { get; set; }
}

public class ApiTeam
{
    public int Id { get; set; }
    public string Slug { get; set; }
    public string Abbreviation { get; set; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; }

    [JsonPropertyName("short_display_name")]
    public string ShortDisplayName { get; set; }

    public string Name { get; set; }
    public string Location { get; set; }
    public string League { get; set; }
    public string Division { get; set; }
}

public class SingleTeamResponse
{
    public ApiTeam Data { get; set; }
}

public class TeamsResponse
{
    public List<ApiTeam> Data { get; set; } = new List<ApiTeam>();
}
