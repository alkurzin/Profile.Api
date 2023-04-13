using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Profile.Service.Commands.Profile;

namespace Profile.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : Controller
    {
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        ///Добавить анкету
        /// </summary>
        [HttpPost("")]
        public async Task<Domain.Profile.Profile> AddTask([FromBody] AddProfileCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
