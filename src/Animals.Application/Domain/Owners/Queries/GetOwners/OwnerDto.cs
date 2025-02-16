namespace Animals.Application.Domain.Owners.Queries.GetOwners;

public record OwnerDto(
    Guid Id,
    string FirstName, 
    string LastName,
    string? MiddleName,
    string Email,
    string PhoneNumber);
