using Account.Api.Account.V1.Transfer;
using Account.Application.UseCases.Transfer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Account.Api.Account.V1
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("v{version:apiVersion}/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("transfer")]
        public async Task<IActionResult> Post(TransferAccountRequest request)
        {
            var response = await _mediator.Send((TransferAccountCommand)request);

            return Ok(response);
        }
    }
}
