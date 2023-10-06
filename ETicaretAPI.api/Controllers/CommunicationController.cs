using ETicaretAPI.application.Mediators.Commands.Communication.CommunicationCreate;
using ETicaretAPI.application.Mediators.Commands.Communication.CommunicationEnd;
using ETicaretAPI.application.Mediators.Commands.Communication.CommunicationEndForAppuserId;
using ETicaretAPI.application.Mediators.Queries.Communication.CommunicationInfoForCommunicationPerson;
using ETicaretAPI.application.Mediators.Queries.Communication.CommunicationInfoForUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommunicationController : ControllerBase
    {
        private readonly IMediator mediator;

        public CommunicationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("CommunicationCreate")]
        public async Task<IActionResult> CommunicationCreate([FromQuery] CommunicationCreateCommandRequest communicationCreateCommandRequest)
        {
            CommunicationCreateCommandResponse response = await mediator.Send(communicationCreateCommandRequest);
            if (response.isSuccess)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpGet]//sonradan [httpDelete] yap
        [Route("CommunicationEnd")]
        public async Task<IActionResult> CommunicationEnd([FromQuery] CommunicationEndCommandRequest communicationEndCommandRequest)
        {
            CommunicationEndCommandResponse response = await mediator.Send(communicationEndCommandRequest);
            if (response.result)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpGet]
        [Route("CommunicationEndForAppuserId")]
        public async Task<IActionResult> CommunicationEndForAppuserId([FromHeader] CommunicationEndForAppuserIdCommandRequest communicationEndForAppuserIdCommandRequest)
        {
            CommunicationEndForAppuserIdCommandResponse response = await mediator.Send(communicationEndForAppuserIdCommandRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("CommunicationInfoForUser")]
        public async Task<IActionResult> CommunicationInfoForUser([FromQuery] CommunicationInfoForUserQueryRequest communicationInfoForUserQueryRequest)
        {
            CommunicationInfoForUserQueryResponse response = await mediator.Send(communicationInfoForUserQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("CommunicationInfoForCommunicationPerson")]
        public async Task<IActionResult> CommunicationInfoForCommunicationPerson([FromQuery] CommunicationInfoForCommunicationPersonQueryRequest forCommunicationPersonQueryRequest)
        {
            CommunicationInfoForCommunicationPersonQueryResponse response = await mediator.Send(forCommunicationPersonQueryRequest);
            return Ok(response);
        }
    }
}
