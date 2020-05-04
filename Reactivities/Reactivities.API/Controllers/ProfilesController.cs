using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reactivities.Application.Profiles;
using System.Threading.Tasks;

namespace Reactivities.API.Controllers
{
    public class ProfilesController : BaseController
    {
        [HttpGet("{username}")]
        public async Task<ActionResult<Profile>> Get(string username)
        {
            return await Mediator.Send(new Details.Query { UserName = username });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Edit(Edit.Command command)
        {
            return await Mediator.Send(command);
        }
    }
}
