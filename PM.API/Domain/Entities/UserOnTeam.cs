using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PM.API.Domain.Entities
{
    public partial class UserOnTeam
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        [InverseProperty("UserOnTeam")]
        public virtual Team Team { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserOnTeam")]
        public virtual User User { get; set; }
    }
}
