using Animals.Core.Domain.Animals.Models;

namespace Animals.Core.Domain.Animals.Common;

public interface IAnimalsRepository
{
    Task<Animal> GetById(Guid id, CancellationToken cancellationToken);

    void Add(Animal animal);

    void Delete(Animal animal);
}