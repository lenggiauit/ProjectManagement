using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PM.API.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            Todo = new HashSet<Todo>();
            UserOnTeam = new HashSet<UserOnTeam>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(250)]
        public string UserName { get; set; }
        [StringLength(250)]
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public Guid? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(255)]
        public string Avatar { get; set; }
        [StringLength(250)]
        public string Email { get; set; }
        public Guid? RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty("User")]
        public virtual Role Role { get; set; }
        [InverseProperty("AssigneeNavigation")]
        public virtual ICollection<Todo> Todo { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserOnTeam> UserOnTeam { get; set; } 
        public virtual List<Permission> Permissions { get; set; }
        public virtual List<Team> Teams { get; set; }
    }
}
