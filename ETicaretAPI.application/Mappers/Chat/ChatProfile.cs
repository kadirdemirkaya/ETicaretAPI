using AutoMapper;
using ETicaretAPI.application.DTOs.Chat;
using ETicaretAPI.application.Mediators.Commands.Chat.MessageCreate;
using ETicaretAPI.domain.Entites;

namespace ETicaretAPI.application.Mappers.Chat
{
    public class ChatProfile : Profile
    {
        public ChatProfile()
        {
            CreateMap<CommunicationMessage, MessageDto>().ReverseMap();
            CreateMap<MessageCreateCommandRequest, MessageDto>().ReverseMap();
        }
    }
}
