using  API.Models;
using API.Data;
namespace API.Services.Interfaces
{
    public interface IMunicipalityService
    {
       public  Task<List<Municipality>> GetAllMunicipalites();
         public Task<Municipality> GetMunicipalityById(int id);


    }
}