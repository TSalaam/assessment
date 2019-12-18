using System.Runtime.Serialization;

namespace Zapper.Payment.Api.Models
{
    public class Merchant
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "id")]
        public int Id { get; set; }
    }
}
