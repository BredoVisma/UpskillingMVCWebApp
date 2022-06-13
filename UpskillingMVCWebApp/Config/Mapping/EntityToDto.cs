using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using UpskillingMVCWebApp.Data.Entities;
using UpskillingMVCWebApp.Models;

namespace UpskillingMVCWebApp.Config.Mapping
{
    public class EntityToDto : Profile
    {
        public EntityToDto()
        {
            CreateMap<Issue, IssueDto>();
            CreateMap<Project, ProjectDto>();
        }
    }
}
