using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Commands.Faculties
{
    public class Details
    {
        public class Query : IRequest<FacultyDto>
        {
            public int FacultyID { get; set; }
        }

        public class Handler : IRequestHandler<Query, FacultyDto>
        {
            private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<FacultyDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var faculty = await _context.Faculties.FindAsync(request.FacultyID);
                var result = _mapper.Map<FacultyDto>(faculty);

                return result;
            }
        }

    }
}