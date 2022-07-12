using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Commands.Faculties
{
    public class Details
    {
        public class Query : IRequest<FlatFacultyDTO>
        {
            public int FacultyID { get; set; }
        }

        public class Handler : IRequestHandler<Query, FlatFacultyDTO>
        {
            private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<FlatFacultyDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var faculty = await _context.Faculties
                    .Include(f => f.Major)
                    .Include(f => f.Level)
                    .Include(f => f.FacultySemesters)
                    .ThenInclude(fs => fs.Semester)
                    .Where(f => f.FacultyID == request.FacultyID)
                    .FirstOrDefaultAsync();
                
                var result = _mapper.Map<FlatFacultyDTO>(faculty);

                return result;
            }
        }

    }
}