﻿using Microsoft.EntityFrameworkCore;

using Zapper.Payment.Api.Models;

namespace Zapper.Payment.Api.Entities {

    public class TransactionContext : DbContext {

        public TransactionContext(DbContextOptions<TransactionContext> options)
            : base(options) {
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseInMemoryDatabase("Transactions");
            }
        }
    }
}