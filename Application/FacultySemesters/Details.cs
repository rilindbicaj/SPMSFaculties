using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.FacultySemesters
{
    public class Details
    {
        public class Query : IRequest <FacultySemesterDto>
        {
            public int FacultyID {get; set;}
        }

        public class Handler : IRequestHandler<Query, FacultySemesterDto>
        {
           private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<FacultySemesterDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var facultysemester = await _context.FacultySemesters.FindAsync(request.FacultyID);
                var result =_mapper.Map<FacultySemesterDto>(facultysemester);
                return result;
            }
        }

    }
}