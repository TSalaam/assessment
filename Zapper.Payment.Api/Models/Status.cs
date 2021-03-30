using System.ComponentModel;

namespace Zapper.Payment.Api.Models {

    public enum Status {

        [Description("Processing")]
        Processing = 0,
        [Description("Success")]
        Success = 1,
        [Description("Failed")]
        Failed = 2,
        [Description("Rejected")]
        Rejected = 3,
        [Description("Error")]
        Error = 4
    }
}