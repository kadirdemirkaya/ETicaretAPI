using ETicaretAPI.application.DTOs.Communication;
using ETicaretAPI.domain.Entites;

namespace ETicaretAPI.application.Mediators.Queries.Communication.CommunicationInfoForCommunicationPerson
{
    public class CommunicationInfoForCommunicationPersonQueryResponse
    {
        public List<CommunicationForPersonDto?> CommunicationForPersonDtos { get; set; }
    }
}
