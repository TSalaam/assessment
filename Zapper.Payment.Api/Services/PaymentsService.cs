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

        public PaymentsService(IPaymentsRepository paymentsRepository) {

            _paymentsRepository = paymentsRepository;
        }

        public async Task<List<Transaction>> GetList(TxSearchRequest request) {

            //Resolve status enum

            Status status = request.StatusDescription.GetEnumFromDescription<Status>();

            request.Status = status;

            return await _paymentsRepository.GetList(request);
        }
    }
}
