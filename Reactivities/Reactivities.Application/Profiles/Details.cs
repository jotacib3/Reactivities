using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Reactivities.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Reactivities.Application.Profiles
{
    public class Details
    {
        public class Query : IRequest<Profile> 
        {
            public string UserName { get; set; }
        }

        public class Handler : IRequestHandler<Query, Profile>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Profile> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users
                    .Include(x => x.Photos)
                    .SingleOrDefaultAsync(x => x.UserName == request.UserName);

                //if (user == null)
                //    throw new RestException(HttpStatusCode.NotFound, new { user = "Not Found " });

                return new Profile
                {
                    DisplayName = user.DisplayName,
                    UserName = user.UserName,
                    Image = user.Photos.FirstOrDefault(x => x.IsMain)?.Url,
                    Bio = user.Bio
                };
            }
        }
    }
}
