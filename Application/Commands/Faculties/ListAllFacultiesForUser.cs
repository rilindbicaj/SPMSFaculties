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

                //Can't seem to make it work without falling back to querying with SQL

                string query = $"select f.facultyid, f.facultyname, f.levelid, f.majorid from faculties as f join userfaculties as uf on f.FacultyID = uf.facultyid where uf.userid = '{request.UserID.ToString().ToUpper()}'";

                var faculties = _context.Faculties.FromSqlRaw(query).ToList();
                var result = _mapper.Map<List<FlatFacultyDTO>>(faculties);

                return result;
            }
        }
    }
}