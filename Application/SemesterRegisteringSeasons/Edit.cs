using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using System;
using Domain;
using System.Collections.Generic;

namespace Application.SemesterRegisteringSeasons
{
    public class Edit
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
                var semesterRegisteringSeason = await _context.SemesterRegisteringSeasons.FindAsync(request.SemesterRegisteringSeasonID);

                if(semesterRegisteringSeason == null)
                    throw new Exception ("Could not find SemesterRegisteringSeason");

                semesterRegisteringSeason.RegisteringSeasonName = request.RegisteringSeasonName ?? semesterRegisteringSeason.RegisteringSeasonName;
                semesterRegisteringSeason.StartDate = request.StartDate; //Operator '??' cannot be applied to operands of type 'DateTime' and 'DateTime'
                semesterRegisteringSeason.EndDate = request.EndDate; //Operator '??' cannot be applied to operands of type 'DateTime' and 'DateTime'
                semesterRegisteringSeason.CurrentStatus = request.CurrentStatus; //Operator '??' cannot be applied to operands of type 'int' and 'int'
                semesterRegisteringSeason.Faculty = request.Faculty; //Operator '??' cannot be applied to operands of type 'int' and 'int'
                semesterRegisteringSeason.Semester = request.Semester; //Operator '??' cannot be applied to operands of type 'int' and 'int'
                

                var success = await _context.SaveChangesAsync() > 0;
        
                if(success) return Unit.Value;
        
                throw new Exception ("Problem saving changes");
            }
        }
    }
}