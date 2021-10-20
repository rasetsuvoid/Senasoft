using Microsoft.AspNetCore.Identity;
using Senasoft.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senasoft.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Column(TypeName = "nvarchar(100)")]
        public string Cedula { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }



    }
}
