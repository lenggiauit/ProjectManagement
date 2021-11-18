using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Resources
{
    public class UserResource
    { 
        public Guid Id { get; set; }
        public string Name { get; set; }
        public RoleResource Role { get; set; }
        public string AccessToken { get; set; }
        public string Email { get; set; } 
        public bool IsActive { get; set; }
        public List<PermissionResource> Permissions { get; set; }
        public List<TeamResource> Teams { get; set; }


    }
}
