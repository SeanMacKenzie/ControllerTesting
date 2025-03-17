using System.Text.Json.Serialization;

namespace ControllerTesting.Models;

public class Player
{
    public int ApiId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public int DebutYear { get; set; }
    public string Jersey { get; set; }
    public string College { get; set; }
    public string Position { get; set; }
    public bool IsActive { get; set; }
    public string BirthPlace { get; set; }
    public string DateOfBirth { get; set; }
    public int Age { get; set; }
    public string Height { get; set; }
    public string Weight { get; set; }
    public string Draft { get; set; }
    public string BatThrows { get; set; }
    public Team Team { get; set; }
}

public class ApiPlayer
{
    public int Id { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("full_name")]
    public string FullName { get; set; }

    [JsonPropertyName("debut_year")]
    public int DebutYear { get; set; }

    public string Jersey { get; set; }
    public string College { get; set; }
    public string Position { get; set; }
    public bool Active { get; set; }

    [JsonPropertyName("birth_place")]
    public string BirthPlace { get; set; }

    public string Dob { get; set; }
    public int Age { get; set; }
    public string Height { get; set; }
    public string Weight { get; set; }
    public string Draft { get; set; }

    [JsonPropertyName("bat_throws")]
    public string BatThrows { get; set; }
    public ApiTeam Team { get; set; }
}

public class SinglePlayerResponse
{
    public ApiPlayer Data { get; set; }
}

public class PlayersResponse
{
    public List<ApiPlayer> Data { get; set; } = new List<ApiPlayer>();
}
