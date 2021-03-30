using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zapper.Payment.Api.Entities;
using Zapper.Payment.Api.Models;

namespace Zapper.Payment.Api.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase {

        private readonly ILogger<PaymentsController> _logger;

        private readonly TransactionContext _context;

        public PaymentsController(ILogger<PaymentsController> logger, TransactionContext context) {

            _logger = logger;
            _context = context;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Transaction>> Create(Transaction transaction) {

            _logger.LogInformation("Creating new transaction");

            _context.Transactions.Add(transaction);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}