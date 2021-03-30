﻿using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using FluentValidation.Results;

using DataAnnotations = System.ComponentModel.DataAnnotations;

namespace Zapper.Payment.Api.Models {

    public class ValidationResultModel {

        [JsonProperty(PropertyName = "Message")]
        public string Message { get; }

        [JsonProperty(PropertyName = "Errors")]
        public List<ValidationError> Errors { get; }

        [JsonProperty(PropertyName = "StatusCode")]
        public int StatusCode { get; set; }

        [JsonProperty(PropertyName = "Status")]
        public string Status { get; set; } = "UNPROCESSABLEENTITY";

        [JsonProperty(PropertyName = "Source")]
        public string Source { get; set; }

        public ValidationResultModel(List<DataAnnotations.ValidationResult> validationResults, int statusCode, string status, string source) {
            Message = "Validation Failed. See 'Errors' property for details";
            Errors = validationResults.Select(x => new ValidationError(null, x.ErrorMessage)).ToList();
            StatusCode = statusCode;
            Status = status;
            Source = source;
        }

        public ValidationResultModel(ValidationResult validationResult, int statusCode, string status, string source) {
            Message = "Validation Failed. See 'Errors' property for details";
            Errors = validationResult.Errors.Select(x => new ValidationError(x.PropertyName, x.ErrorMessage)).ToList();
            StatusCode = statusCode;
            Status = status;
            Source = source;
        }
    }

    public class ValidationError {

        [JsonProperty(PropertyName = "Field", NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; }

        [JsonProperty(PropertyName = "ErrorMessage")]
        public string ErrorMessage { get; }

        public ValidationError(string field, string errorMessage) {
            Field = field != string.Empty ? field : null;
            ErrorMessage = errorMessage;
        }
    }
}
