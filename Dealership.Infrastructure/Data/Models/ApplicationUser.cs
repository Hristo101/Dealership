        using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Dealership.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Query> Queries { get; set; } = new List<Query>();
    }

}
