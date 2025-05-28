namespace WebApi.Services.Dtos;

public class BookFilterDto
{
    public string? Title { get; set; }

    public string? Author { get; set; }

    public string? Type { get; set; }

    public string? ISBN { get; set; }

    public string? Category { get; set; }
}
