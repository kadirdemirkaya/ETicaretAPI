using ETicaretAPI.domain.Entites.Base;

namespace ETicaretAPI.domain.Entites
{
    public class CommunicationMessage : EntityBase
    {
        public string? message { get; set; }
        public bool? PersonMessage { get; set; }


        public CommunicationCustomerPerson CommunicationCustomerPerson { get; set; }
        public Guid CommunicationCustomerPersonId { get; set; }
    }
}
