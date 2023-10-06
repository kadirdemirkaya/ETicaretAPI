using ETicaretAPI.application.DTOs.Chat;
using MediatR;

namespace ETicaretAPI.application.Mediators.Commands.Chat.MessageCreate
{
    public class MessageCreateCommandRequest : IRequest<MessageCreateCommandResponse>
    {
        public MessageDto MessageDto { get; set; }
    }
}
