using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using Domain;
using System;
using System.Collections.Generic;

namespace Application.SemesterRegisteringSeasons
{
    public class Create
    {
        public class Command : IRequest
        {
        public int SemesterRegisteringSeasonID { get; set; }
        public string RegisteringSeasonName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CurrentStatus { get; set; }
        public int Faculty { get; set; }
        public int Semester { get; set; }

        public FacultySemester FacultySemester { get; set; }
        public ICollection<RegisteredSemester> RegisteredSemesters { get; set; }
        public SeasonStatus SeasonStatus { get; set; }


        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly FacultyDBContext _context;

            public Handler(FacultyDBContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var semesterRegisteringSeason = new SemesterRegisteringSeason
                {
                    SemesterRegisteringSeasonID = request.SemesterRegisteringSeasonID,
                    RegisteringSeasonName = request.RegisteringSeasonName,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    CurrentStatus = request.CurrentStatus,
                    Faculty = request.Faculty,
                    Semester = request.Semester,
                    FacultySemester = request.FacultySemester,
                    RegisteredSemesters = request.RegisteredSemesters,
                    SeasonStatus = request.SeasonStatus,
                };

                _context.SemesterRegisteringSeasons.Add(semesterRegisteringSeason);
                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception ("Problem saving changes");
            }
        }
    }
}
