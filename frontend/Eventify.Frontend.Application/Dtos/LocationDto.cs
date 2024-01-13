namespace Eventify.Frontend.Application;

public record LocationDto(string? Name, string AddressLine1, string? AddressLine2, string PostalCode,
 string City, string Country, double Latitude, double Longitude, string? AdditionalDirections = null);