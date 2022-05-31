using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Faculties
{
    public class ListFacultiesForUser
    {
        public class Query : IRequest<List<FlatFacultyDTO>>
        {
            public Guid UserID { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<FlatFacultyDTO>>
        {
            private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<FlatFacultyDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var faculties = await _context.Faculties
                .Select(f => new Faculty
                {
                    FacultyID = f.FacultyID,
                    FacultyName = f.FacultyName,
                    MajorID = f.MajorID,
                    LevelID = f.LevelID,
                    Major = f.Major,
                    Level = f.Level,
                    FacultySemesters = f.FacultySemesters
                        .Select(fs => new FacultySemester
                        {
                            FacultyID = fs.FacultyID,
                            SemesterID = fs.SemesterID,
                            Semester = new Semester { SemesterID = fs.Semester.SemesterID, SemesterName = fs.Semester.SemesterName }
                        }).ToList()
                })
                .ToListAsync();

                var result = _mapper.Map<List<FlatFacultyDTO>>(faculties);

                return result;
            }
        }
    }
}