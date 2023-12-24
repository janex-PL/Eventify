namespace Eventify.Frontend.Application;

public record EventDto(int Id, string Name, DateTime StartingAt, string ImageCoverUrl, int TotalAtendees, LocationDto Location);
