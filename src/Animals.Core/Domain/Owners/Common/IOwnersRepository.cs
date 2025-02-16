using Animals.Core.Domain.Owners.Models;

namespace Animals.Core.Domain.Owners.Common;

public interface IOwnersRepository
{
    Task<Owner> GetById(Guid ownerId, CancellationToken cancellationToken);

    void Add(Owner owner);

    void Delete(Owner owner);
}