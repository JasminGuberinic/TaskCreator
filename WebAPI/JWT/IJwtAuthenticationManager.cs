using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string name, string password);
    }
}
