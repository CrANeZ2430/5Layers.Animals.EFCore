using _5Layers.Animals.Persistence.EFCore.AnimalsDb;
using Animals.Application.Common;
using Animals.Application.Domain.Owners.Queries.GetOwners;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OwnerDto = Animals.Application.Domain.Owners.Queries.GetOwners.OwnerDto;

namespace Animals.Infrastructure.Application.Domain.Owners;

internal class GetOwnersQueryHandler(AnimalsDbContext dbContext)
    : IRequestHandler<GetOwnersQuery, PageResponse<OwnerDto[]>>
{
    public async Task<PageResponse<OwnerDto[]>> Handle(
        GetOwnersQuery query, 
        CancellationToken cancellationToken)
    {
        var sqlQuery = dbContext
        .Owners
        .AsNoTracking();
            //.Include(x => x.Owners);

        var skip = query.PageSize * (query.Page - 1);

        var count = sqlQuery.Count();

        var animals = await sqlQuery
            .OrderBy(a => a.FirstName)
            .Skip(skip)
            .Take(query.PageSize)
            .Select(x => new OwnerDto(
                x.Id,
                x.FirstName,
                x.LastName,
                x.MiddleName,
                x.Email,
                x.PhoneNumber
                ))
            .ToArrayAsync(cancellationToken);

        return new PageResponse<OwnerDto[]>(count, animals);
    }
}
