namespace Animals.Api.Domain.Owners.Records;

public record UpdateOwnerRequest(
    string FirstName,
    string LastName,
    string? MiddleName,
    string Email,
    string PhoneNumber);