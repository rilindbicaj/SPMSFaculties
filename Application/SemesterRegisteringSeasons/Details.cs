using System;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.SemesterRegisteringSeasons
{
    public class Details
    {
        public class Query : IRequest <SemesterRegisteringSeasonDto>
        {
            public int SemesterRegisteringSeasonID {get; set;}
        }

        public class Handler : IRequestHandler<Query, SemesterRegisteringSeasonDto>
        {
             private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<SemesterRegisteringSeasonDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var semesterRegisteringSeason = await _context.SemesterRegisteringSeasons.FindAsync(request.SemesterRegisteringSeasonID);

                var result =_mapper.Map<SemesterRegisteringSeasonDto>(semesterRegisteringSeason);

                return result;
            }
        }

    }
}