﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PM.API.Domain.Entities
{
    public partial class Project
    {
        public Project()
        {
            Todo = new HashSet<Todo>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public Guid? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatebDate { get; set; }
        public Guid? StatusId { get; set; }

        [ForeignKey(nameof(StatusId))]
        [InverseProperty(nameof(ProjectStatus.Project))]
        public virtual ProjectStatus Status { get; set; }
        [InverseProperty("Project")]
        public virtual ICollection<Todo> Todo { get; set; }
    }
}
