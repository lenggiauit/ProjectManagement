using AutoMapper;
using PM.API.Domain.Entities;
using PM.API.Domain.Models;
using PM.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        { 
            CreateMap<User, UserResource>(); 
            CreateMap<Role, RoleResource>();
            CreateMap<Permission, PermissionResource>();
            CreateMap<Team, TeamResource>();
            // projects
            CreateMap<Project, ProjectResource>();
            CreateMap<Project, ProjectDetailResource>(); 
            CreateMap<ProjectStatus, ProjectStatusResource>(); 
            // Ref
            CreateMap<RefModel, RefResource>(); 
            CreateMap<Conversation,ConversationResource>();
            CreateMap<User, ConversationerResource>();
            CreateMap<ConversationMessage, ConversationMessageResource>(); 
            CreateMap<Todo, TodoResource>();
              
        }
    }
}