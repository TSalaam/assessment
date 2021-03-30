using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Zapper.Payment.Api.Models;
using Zapper.Payment.Api.Models.Requests;

namespace Zapper.Payment.Api.Services.Interfaces {
    
    public interface IPaymentsService {

        public Task<List<Transaction>> GetList(TxSearchRequest request);
    }
}
