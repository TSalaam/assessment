using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Zapper.Payment.Api.Extensions;
using Zapper.Payment.Api.Models;
using Zapper.Payment.Api.Services.Interfaces;
using Zapper.Payment.Api.Models.Requests;
using Zapper.Payment.Api.Repositories.Interfaces;

namespace Zapper.Payment.Api.Services {

    public class PaymentsService : IPaymentsService {

        private readonly IPaymentsRepository _paymentsRepository;

        private readonly int _maxTransactionValue;

        public PaymentsService(IPaymentsRepository paymentsRepository) {

            _paymentsRepository = paymentsRepository;

            //TODO: Read from appsettings

            _maxTransactionValue = 5000;
        }

        public async Task<int> AddTransaction(Transaction transaction) {

            if (transaction.Amount > _maxTransactionValue) {
                throw new ArgumentOutOfRangeException(nameof(transaction.Amount), $"Specified amount of R {transaction.Amount} exceeds maximum allowed transaction value");
            }

            return await _paymentsRepository.AddTransaction(transaction);
        }

        public async Task<List<Transaction>> GetList(TxSearchRequest request) {

            //Resolve status enum

            Status status = request.StatusDescription.GetEnumFromDescription<Status>();

            request.Status = status;

            return await _paymentsRepository.GetList(request);
        }
    }
}
