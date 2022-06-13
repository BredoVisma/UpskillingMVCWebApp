using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using UpskillingMVCWebApp.Data.Entities;
using UpskillingMVCWebApp.Models;

namespace UpskillingMVCWebApp.Config.Mapping
{
    public class DtoToEntity : Profile
    {
        public DtoToEntity()
        {
            CreateMap<IssueEditDto, Issue>();
            CreateMap<IssueDto, Issue>();
            CreateMap<ProjectEditDto, Project>();
        }
    }
}
