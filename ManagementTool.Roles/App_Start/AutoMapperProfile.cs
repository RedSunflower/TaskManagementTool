using AutoMapper;
using ManagementTool.DAL.Models;
using ManagementTool.Roles.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementTool.Roles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TrackingTask, TrackingTaskViewModel>();
            CreateMap<TrackingTaskViewModel, TrackingTask>();
        }
    }
}