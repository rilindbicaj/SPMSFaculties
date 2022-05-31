using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using AutoMapper;
using Domain;


namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            //source to target
            CreateMap<Faculty, FacultyDto>();
            CreateMap<Faculty, Faculty>();

            CreateMap<FacultySemester, FacultySemesterDto>();
            CreateMap<FacultySemester, FacultySemester>();

            CreateMap<Level, LevelDto>();
            CreateMap<Level, Level>();

            CreateMap<Location, LocationDto>();
            CreateMap<Location, Location>();

            CreateMap<Major, MajorDto>();
            CreateMap<Major, Major>();

            CreateMap<RegisteredSemester, RegisteredSemesterDto>();
            CreateMap<RegisteredSemester, RegisteredSemester>();

            CreateMap<SeasonStatus, SeasonStatusDto>();
            CreateMap<SeasonStatus, SeasonStatus>();

            CreateMap<Semester, SemesterDto>();
            CreateMap<Semester, Semester>();

            CreateMap<SemesterRegisteringSeason, SemesterRegisteringSeasonDto>();
            CreateMap<SemesterRegisteringSeason, SemesterRegisteringSeason>();

            CreateMap<UserFaculty, UserFacultyDto>();
            CreateMap<UserFaculty, UserFaculty>();

            CreateMap<Faculty, FlatFacultyDTO>()
            .ForMember(dest => dest.Major, opt => opt.MapFrom(src => src.Major.MajorName))
            .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level.LevelName))
            .AfterMap((src, dest, rc) =>
            {
                var list = new List<Semester>();
                foreach (var fs in src.FacultySemesters)
                {
                    list.Add(fs.Semester);
                }
                dest.Semesters = list;
            });

        }
    }
}