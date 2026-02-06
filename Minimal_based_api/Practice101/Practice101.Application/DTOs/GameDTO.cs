namespace GameApi.Api.DTOs;
public record GameDTO(Guid Id, string Title, string Genre, DateTimeOffset ReleaseDate, double Rating);
