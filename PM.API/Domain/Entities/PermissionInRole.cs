using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PM.API.Domain.Entities
{
    public partial class PermissionInRole
    {
        public Guid Id { get; set; }
        public Guid PermissionId { get; set; }
        public Guid RoleId { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual Role Role { get; set; }
    }
}
