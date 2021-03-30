using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.Filters;

using FluentValidation.Results;

using Zapper.Payment.Api.Infrastructure;

namespace Zapper.Payment.Api.Filters {

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.ResultFilterAttribute" />
    public class ValidateFilterAttribute : ResultFilterAttribute {

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        /// <inheritdoc />
        public override void OnResultExecuting(ResultExecutingContext context) {

            base.OnResultExecuting(context);

            // Model validation did not pass

            if (!context.ModelState.IsValid) {

                List<ValidationFailure> validationFailures = new List<ValidationFailure>();

                foreach (var modelStateValue in context.ModelState.Values) {
                    foreach (var item in modelStateValue.Errors) {
                        validationFailures.Add(new ValidationFailure("", item.ErrorMessage));
                    }
                }

                ValidationResult validationResult = new ValidationResult(validationFailures);

                context.Result = new ValidationFailedResult(validationResult, ToString());
            }
        }
    }
}