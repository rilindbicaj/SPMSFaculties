using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Responses;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Persistence;

namespace Application.Queries.Semesters
{
    public class GetSemestersForStudentInFaculty
    {
        public class Query : IRequest<List<SemesterDto>>
        {
    public Guid UserId { get; set; }
    public int FacultyId { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<SemesterDto>>
        {
            private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {

                _context = context;
                _mapper = mapper;

            }

            public async Task<List<SemesterDto>> Handle(Query request, CancellationToken token)
            {

                var semesters = await _context.Semesters
                    .Where(s => s.FacultySemesters.Any(fs =>
                        fs.RegisteringSeasons.Any(ts => 
                            ts.Faculty == request.FacultyId
                            && ts.RegisteredSemesters.Any(rs => 
                                rs.Student == request.UserId)))).ToListAsync();

                return _mapper.Map<List<SemesterDto>>(semesters);

            }

        }
    }
}