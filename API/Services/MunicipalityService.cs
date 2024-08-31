using API.Services.Interfaces;
using API.Models;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;  // Required for EF Core
using System.Collections.Generic;  // Required for List<>
using System.Linq;  // Required for LINQ methods like ToList()
using System.Threading.Tasks;

namespace API.Services
{
    public class MunicipalityService:IMunicipalityService
    {
        private readonly StoreContext _context;

        public MunicipalityService(StoreContext context)
        {
            _context=context;
        }

       public async Task<List<Municipality>> GetAllMunicipalites()
{
    return await _context.Municipalities.ToListAsync();
}

         public Task<Municipality> GetMunicipalityById(int id){
              return null;
         }
    }
}