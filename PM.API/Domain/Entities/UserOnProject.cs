using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PM.API.Domain.Entities
{
    public partial class UserOnProject
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid RoleId { get; set; }

        public virtual Project Project { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
