using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PM.API.Domain.Entities
{
    public partial class PermissionInRole
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PermissionId { get; set; }
        public Guid RoleId { get; set; }

        [ForeignKey(nameof(PermissionId))]
        [InverseProperty("PermissionInRole")]
        public virtual Permission Permission { get; set; }
        [ForeignKey(nameof(RoleId))]
        [InverseProperty("PermissionInRole")]
        public virtual Role Role { get; set; }
    }
}
