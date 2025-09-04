namespace PersonToJson.Models;

public class Person
{
    public required string LastName { get; set; }
    public required string FirstName { get; set; }
    public string? Patronymic { get; set; }
}