using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;

using Zapper.Payment.Api.Entities;
using Zapper.Payment.Api.Models;
using Zapper.Payment.Api.Models.Requests;
using Zapper.Payment.Api.Services.Interfaces;

namespace Zapper.Payment.Api.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase {

        private readonly ILogger<PaymentsController> _logger;

        private readonly TransactionContext _context;

        private readonly IPaymentsService _paymentsService;

        public PaymentsController(ILogger<PaymentsController> logger, TransactionContext context, IPaymentsService paymentsService) {

            _logger = logger;

            _context = context;

            _paymentsService = paymentsService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Transaction>> Create(Transaction transaction) {

            _logger.LogInformation("Creating new transaction");

            _context.Transactions.Add(transaction);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<Transaction>), StatusCodes.Status200OK)]
        [Route("transactionSearch")]
        public async Task<ActionResult<Transaction>> GetAll([FromBody] TxSearchRequest request) {

            _logger.LogInformation("Getting list of transactions");

            var results = await _paymentsService.GetList(request);

            return new OkObjectResult(new {
                Results = results
            });
        }
    }
}