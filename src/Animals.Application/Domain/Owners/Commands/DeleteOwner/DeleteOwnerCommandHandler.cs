using Animals.Core.Common;
using Animals.Core.Domain.Owners.Common;
using MediatR;

namespace Animals.Application.Domain.Owners.Commands.DeleteOwner;

internal class DeleteOwnerCommandHandler(
    IUnitOfWork unitOfWork,
    IOwnersRepository ownerRepository) : IRequestHandler<DeleteOwnerCommand>
{
    public async Task Handle(
        DeleteOwnerCommand request, 
        CancellationToken cancellationToken)
    {
        var owner = await ownerRepository.GetById(request.Id, cancellationToken);
        ownerRepository.Delete(owner);
        await unitOfWork.SaveChangesAsync();
    }
}
