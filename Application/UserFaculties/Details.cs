using System;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.UserFaculties
{
    public class Details
    {
        public class Query : IRequest <UserFacultyDto>
        {
            public Guid UserID {get; set;}
        }

        public class Handler : IRequestHandler<Query, UserFacultyDto>
        {
             private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UserFacultyDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var userfaculty = await _context.UserFaculties.FindAsync(request.UserID);

                var result =_mapper.Map<UserFacultyDto>(userfaculty);

                return result;
            }
        }

    }
}

