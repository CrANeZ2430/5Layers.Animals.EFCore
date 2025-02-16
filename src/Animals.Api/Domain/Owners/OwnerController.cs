using Animals.Api.Domain.Owners.Records;
using Animals.Application.Domain.Owners.Commands.CreateOwner;
using Animals.Application.Domain.Owners.Commands.DeleteOwner;
using Animals.Application.Domain.Owners.Commands.UpdateOwner;
using Animals.Application.Domain.Owners.Queries.GetOwners;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Animals.Api.Domain.Owners
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetOwners(
        [FromQuery][Required] int page = 1,
        [FromQuery][Required] int pageSize = 10,
        CancellationToken cancellationToken = default)
        {
            var query = new GetOwnersQuery(page, pageSize);
            var goods = await mediator.Send(query, cancellationToken);
            return Ok(goods);
        }

        [HttpPost]
        public async Task<ActionResult> AddOwner(
        [FromBody][Required] CreateOwnerRequest request,
        CancellationToken cancellationToken = default)
        {
            var command = new CreateOwnerCommand(
                request.FirstName,
                request.LastName,
                request.MiddleName,
                request.Email,
                request.PhoneNumber);
            var id = await mediator.Send(command, cancellationToken);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOwner(
            [FromRoute] Guid id,
            [FromBody][Required] UpdateOwnerRequest request,
            CancellationToken cancellationToken = default)
        {
            var command = new UpdateOwnerCommand(
                id,
                request.FirstName,
                request.LastName,
                request.MiddleName,
                request.Email,
                request.PhoneNumber);
            await mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOwner(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default)
        {
            var command = new DeleteOwnerCommand(id);
            await mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}
