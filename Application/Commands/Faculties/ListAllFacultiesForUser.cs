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

namespace Application.Commands.Faculties
{
    public class ListAllFacultiesForUser
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
                
                var faculties = _context.Faculties
                    .Where(f => f.UserFaculties.Any(uf => uf.UserID.ToString() == request.UserID.ToString().ToUpper()))
                    .Include(f => f.Major)
                    .Include(f => f.Level)
                    .Include(f => f.FacultySemesters)
                    .ThenInclude(f => f.Semester);
                var result = _mapper.Map<List<FlatFacultyDTO>>(faculties);

                return result;
            }
        }
    }
}