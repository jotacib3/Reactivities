using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reactivities.Application.Followers;
using Reactivities.Application.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reactivities.API.Controllers
{
    [Route("api/profiles")]
    public class FollowersController : BaseController
    {
        [HttpGet]
        public async Task<List<Profile>> GetFollowings(string username, string predicate)
        {
            return await Mediator.Send(new List.Query { Username = username, Predicate = predicate });
        }

        [HttpPost("{username}/follow")]
        public async Task<ActionResult<Unit>> Follow(string username)
        {
            return await Mediator.Send(new Add.Command { UserName = username });
        }

        [HttpDelete("{username}/follow")]
        public async Task<ActionResult<Unit>> Unfollow(string username)
        {
            return await Mediator.Send(new Add.Command { UserName = username });
        }
    }
}
