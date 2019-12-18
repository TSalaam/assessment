using System.Runtime.Serialization;

namespace Zapper.Payment.Api.Models
{
    public class Card
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "cardMask")]
        public string CardMask { get; set; }
        [DataMember(Name = "expiryMonth")]
        public int ExpiryMonth { get; set; }
        [DataMember(Name = "expiryYear")]
        public int ExpiryYear { get; set; }
    }
}
