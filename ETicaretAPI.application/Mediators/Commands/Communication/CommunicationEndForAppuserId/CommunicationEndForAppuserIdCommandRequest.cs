using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.application.Mediators.Commands.Communication.CommunicationEndForAppuserId
{
    public class CommunicationEndForAppuserIdCommandRequest : IRequest<CommunicationEndForAppuserIdCommandResponse>
    {
        [FromHeader]
        public Guid Id { get; set; }
    }
}
