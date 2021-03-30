using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FluentValidation;

using Zapper.Payment.Api.Models;
using Zapper.Payment.Api.Models.Requests;

namespace Zapper.Payment.Api.Validators {

    public class TransactionValidator : AbstractValidator<Transaction> {

        public TransactionValidator() {

            RuleFor(x => x.Merchant.Name).NotEmpty();

            //TODO: Make configurable

            RuleFor(x => x.Amount).NotEmpty().LessThan(5000).WithMessage("Specified amount exceeds maximum allowed transaction value of R5000");
        }
    }
}