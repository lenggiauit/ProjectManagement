using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PM.API.Domain.Entities
{
    public partial class Permission
    { 
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        [NotMapped]
        public virtual List<PermissionInRole> PermissionInRole { get; set; }
    }
}
