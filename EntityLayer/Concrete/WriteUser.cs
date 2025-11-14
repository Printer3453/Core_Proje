using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WriteUser: IdentityUser<int>
    {
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? ImageUrl { get; set; }


    }
}
