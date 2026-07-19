using Microsoft.AspNetCore.Mvc;
using Application.Transactions;
using Application.Transactions.DTOs;

namespace YourFlowAPI.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionsController : ControllerBase
    {

        private readonly ITransactionService _transactionService;

        public TransactionsController(
            ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            ExecuteTransactionRequest dto,
            CancellationToken cancellationToken)
        {
            var transactionId = await _transactionService.ExecuteAsync(
                dto, cancellationToken);

            return Ok(new { id = transactionId });

            //return CreatedAtAction(
            //    nameof(GetById),
            //    new { id = transactionId },
            //    new { id = transactionId });
        }

        //[HttpGet("{id:guid}")]
        //public async Task<IActionResult> GetById(
        //    Guid id,
        //    CancellationToken cancellationToken)
        //{
        //    var transaction = await _transactionService.GetByIdAsync(
        //        id,
        //        cancellationToken);

        //    if (transaction is null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(transaction);
        //}


    }
}
