using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class RegisterDTO
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        public required string Email {get;set;}
        public required string Password {get;set;}
        public required string JMBG { get; set; }

        public  string Pol { get; set; }
        public  DateOnly DatumRodjenja {get;set;}

        public  string AdresaPrebivalista {get;set;}
        public  string OpstinaPrebivalista{get;set;}
    }
}