using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PM.API.Domain.Entities
{
    public partial class Team
    {
        public Team()
        {
            UserOnTeam = new HashSet<UserOnTeam>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsActive { get; set; }
        public Guid? CreateBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        [InverseProperty("Team")]
        public virtual ICollection<UserOnTeam> UserOnTeam { get; set; }
    }
}
