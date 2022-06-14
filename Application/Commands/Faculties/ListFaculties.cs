using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Commands.Faculties
{
    public class ListFaculties
    {
        public class Query : IRequest<List<FacultyDto>> { }

        public class Handler : IRequestHandler<Query, List<FacultyDto>>
        {
            private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<FacultyDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var faculties = await _context.Faculties.ToListAsync();
                var result = _mapper.Map<List<FacultyDto>>(faculties);

                return result;
            }
        }
    }
}