using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Zapper.Payment.Api.Models.Requests {

    public class TxSearchRequest {

        [JsonIgnore]
        public Status Status { get; set; }

        public string StatusDescription { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}