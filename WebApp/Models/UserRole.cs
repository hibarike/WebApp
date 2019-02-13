using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class UserRole
    {
       public ApplicationUser user;
       public IList<string> roles;
    }
}