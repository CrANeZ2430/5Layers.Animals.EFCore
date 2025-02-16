namespace Animals.Api.Domain.Owners.Records;

public record CreateOwnerRequest(
    string FirstName,
    string LastName,
    string? MiddleName,
    string Email,
    string PhoneNumber);