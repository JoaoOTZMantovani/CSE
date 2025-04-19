namespace CSE.API;

public class HealthResponse
{
    public bool Running { get; set; }
    public DateOnly Date { get; set; }
    public string Message { get; set; } = string.Empty;
}
