namespace PersonToJson.Models;

public class Address
{
    public string? Region { get; set; }
    public string? District { get; set; }
    public required string Locality { get; set; }
}