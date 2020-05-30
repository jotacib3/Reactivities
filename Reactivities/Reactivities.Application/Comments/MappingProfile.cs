using AutoMapper;
using Reactivities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reactivities.Application.Comments
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Comment, CommentDto>()
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.Author.UserName))
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.Author.DisplayName))
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.Author.Photos
                    .FirstOrDefault(x => x.IsMain).Url));
        }
    }
}
