using AutoMapper;
using DataLayer.Dto;
using DataLayer.Models.Works;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Mapping
{
    public class SharedMap : Profile
    {
        public SharedMap()
        {
            CreateMap<TaskW, TaskWDto>().ReverseMap();
            CreateMap<Work, WorkDto>().ReverseMap();
            CreateMap<TaskWorkDto, TaskWork>().ReverseMap();

        }
    }
}
