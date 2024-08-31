using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
   public class RegisterDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string JMBG { get; set; }
    public string Pol { get; set; }  
    public DateOnly DatumRodjenja { get; set; }  
    public string AdresaPrebivalista { get; set; }
    public string OpstinaPrebivalista { get; set; }
}

}