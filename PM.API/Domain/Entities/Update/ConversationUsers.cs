﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PM.API.Domain.Entities.Update
{
    public partial class ConversationUsers
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ConversationId { get; set; }
    }
}
