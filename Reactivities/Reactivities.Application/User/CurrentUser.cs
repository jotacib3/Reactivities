using MediatR;
using Microsoft.AspNetCore.Identity;
using Reactivities.Application.Interfaces;
using Reactivities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reactivities.Application.User
{
    public class CurrentUser
    {
        public class Query : IRequest<User> { }

        public class Handler : IRequestHandler<Query, User>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IUserAccesssor _userAccesssor;
            private readonly IJwtGenerator _jwtGeneretaor;

            public Handler(UserManager<AppUser> userManager, IUserAccesssor userAccesssor,
                            IJwtGenerator jwtGeneretaor)
            {
                _userManager = userManager;
                _userAccesssor = userAccesssor;
                _jwtGeneretaor = jwtGeneretaor;
            }
            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByNameAsync(_userAccesssor.GetCurrentUserName());

                return new User
                {
                    DisplayName = user.DisplayName,
                    UserName = user.UserName,
                    Token = _jwtGeneretaor.CreateToken(user),
                    Image = user.Photos.FirstOrDefault(x => x.IsMain)?.Url
                };
            }
        }
    }
}
