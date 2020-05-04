using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reactivities.Application.Photos;
using Reactivities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reactivities.API.Controllers
{
    public class PhotosController: BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Photo>> Add([FromForm]Add.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("{id}/setmain")]
        public async Task<ActionResult<Unit>> SetMaib(string id)
        {
            return await Mediator.Send(new SetMain.Command{ Id = id });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(string id)
        {
            return await Mediator.Send(new Delete.Command { Id = id });
        }

    }
}
