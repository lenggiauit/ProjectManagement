﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Domain.Services.Communication.Request
{
    public class CreateProjectRequest
    { 
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } 
        public Guid StatusId { get; set; }
    }
}
