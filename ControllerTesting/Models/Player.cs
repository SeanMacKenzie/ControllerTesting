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
    public Team Team { get; set; }
}
