using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.UserFaculties
{
    public class ListUserFaculties
    {
        public class Query : IRequest<List<UserFacultyDto>> {}

        public class Handler : IRequestHandler<Query, List<UserFacultyDto>>
        {
            private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<List<UserFacultyDto>> Handle (Query request, CancellationToken cancellationToken)
            {
                var userfaculties = await _context.UserFaculties.ToListAsync();

                var result =_mapper.Map<List<UserFacultyDto>>(userfaculties);

                return result;
            }
        }
    }
}

