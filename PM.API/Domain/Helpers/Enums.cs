using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Domain.Helpers
{
    public enum ResultCode
    {
        Invalid = -2,
        Unknown = -1,
        UnAuthorized = 0, 
        Success = 1,
        Valid = 11,
        Error = 2,
        RegisterExistEmail = 3,
        RegisterExistUserName = 4,
        NotExistUser = 5,
        NotExistEmail = 51,

    }
}
