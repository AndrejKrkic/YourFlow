using Application.Accounts;
using Application.Accounts.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace YourFlowAPI.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddAccountResult), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AddAccountResult>> Add(
            AddAccountRequest request,
            CancellationToken cancellationToken)
        {
            var account = await _accountService.AddAsync(request, cancellationToken);

            return Created($"/api/accounts/{account.AccountId}", account);
        }
    }
}
