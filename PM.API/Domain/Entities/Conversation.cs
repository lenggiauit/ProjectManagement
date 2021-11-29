using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PM.API.Domain.Entities
{
    public partial class Conversation
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string LastMessage { get; set; }
        public DateTime? LastMessageDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        [NotMapped]
        public virtual List<User> Conversationers { get; set; }
    }
}
