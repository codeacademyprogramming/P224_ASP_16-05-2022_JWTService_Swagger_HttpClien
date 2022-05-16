using Microsoft.Extensions.Configuration;
using P224FirstApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P224FirstApi.Interfaces
{
    public interface IJWTService
    {
        string CreateToken(AppUser appUser, IConfiguration configuration, IList<string> roles);
    }
}
