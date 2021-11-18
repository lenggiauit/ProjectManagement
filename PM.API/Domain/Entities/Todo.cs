using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PM.API.Domain.Entities
{
    public partial class Todo
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DueDate { get; set; }
        public Guid? Assignee { get; set; }
        public Guid? TodoTypeId { get; set; }
        public Guid? TodoStatusId { get; set; }
        public Guid? ProjectId { get; set; }
        public Guid? PriorityId { get; set; }
        public int? PositionX { get; set; }
        public int? PositionY { get; set; }
        public int? PositionW { get; set; }
        public int? PositionH { get; set; }

        [ForeignKey(nameof(Assignee))]
        [InverseProperty(nameof(User.Todo))]
        public virtual User AssigneeNavigation { get; set; }
        [ForeignKey(nameof(PriorityId))]
        [InverseProperty("Todo")]
        public virtual Priority Priority { get; set; }
        [ForeignKey(nameof(ProjectId))]
        [InverseProperty("Todo")]
        public virtual Project Project { get; set; }
        [ForeignKey(nameof(TodoStatusId))]
        [InverseProperty("Todo")]
        public virtual TodoStatus TodoStatus { get; set; }
        [ForeignKey(nameof(TodoTypeId))]
        [InverseProperty("Todo")]
        public virtual TodoType TodoType { get; set; }
    }
}
