using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using Zapper.Payment.Api.Entities;
using Zapper.Payment.Api.Models;
using Zapper.Payment.Api.Models.Requests;
using Zapper.Payment.Api.Repositories.Interfaces;

namespace Zapper.Payment.Api.Repositories {

    public class PaymentsRepository : IPaymentsRepository {

        private readonly IConfiguration _config;

        public PaymentsRepository(IConfiguration config) {
            _config = config;
        }

        public async Task<int> AddTransaction(Transaction transaction) {

            var optionsBuilder = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<TransactionContext>();

            using (var db = new TransactionContext(optionsBuilder.Options)) {                

                db.Transactions.Add(transaction);

                return await db.SaveChangesAsync();
            }
        }

        public async Task<List<Transaction>> GetList(TxSearchRequest request) {

            var optionsBuilder = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<TransactionContext>();

            using (var db = new TransactionContext(optionsBuilder.Options)) {

                var entries = db.Transactions
                    .Where(b => b.StatusId == request.Status)
                    .OrderBy(b => b.TransactionUtcDate)
                    .ToList();

                return entries;
            }
        }
    }
}
