using System;
using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Application.Requests;
using Application.Responses;
using AutoMapper;
using AutoMapper.Internal;
using Domain;
using Microsoft.Data.SqlClient;
using MongoDB.Bson;


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

            CreateMap<LocationUpdateRequest, Location>();

            CreateMap<BusScheduleSlotCreateRequest, BusScheduleSlot>().AfterMap((src, dest, rc) =>
            {
                dest.SlotId ??= ObjectId.GenerateNewId();
            });

            CreateMap<BusScheduleInformationUpdateRequest, BusSchedule>();
            CreateMap<BusScheduleSlotsUpdateRequest, BusSchedule>();
            CreateMap<BusScheduleCreateRequest, BusSchedule>();
            
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

            CreateMap<Location, LocationResponse>();

            CreateMap<Location, BusScheduleResponse>()
                .ForMember(dest => dest.BusScheduleID, opt => opt.MapFrom(src => src.LocationId))
                .AfterMap((dest, src, rc) => rc.Mapper.Map(dest.BusSchedule, src));
            CreateMap<BusSchedule, BusScheduleResponse>();

            CreateMap<Faculty, FlatFacultyDTO>()
            .ForMember(dest => dest.Major, opt => opt.MapFrom(src => src.Major.MajorName))
            .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level.LevelName));

        }
    }
}