using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class UpdateUserDTO
    {
            public required string FirstName { get; set; }
            public required string LastName { get; set; }
            public required string JMBG { get; set; }
            public required string Email { get; set; }
            public required string Username { get; set; }
            public  string AdresaPrebivalista {get;set;}
            public  string OpstinaPrebivalista{get;set;}
    }
}