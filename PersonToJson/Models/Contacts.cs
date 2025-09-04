namespace PersonToJson.Models;

public class Contacts
{
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public required Address Address { get; set; }
}