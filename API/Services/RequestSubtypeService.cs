using API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace API.Services
{
    public class RequestSubtypeService
    {
        private readonly StoreContext _context;

        public RequestSubtypeService(StoreContext context)
        {
            _context=context;
        }

        public async Task AddRequestSubtype(RequestSubtype requestSubtype)
        {
            _context.RequestSubtypes.Add(requestSubtype);
            _context.SaveChanges();
        }
        public async Task<RequestSubtype> GetRequestSubtype(int requestSubtypeId)
        {
            var requestSubtype = await _context.RequestSubtypes.FirstOrDefaultAsync(rst => rst.RequestSubtypeID  == requestSubtypeId);
            return requestSubtype;
        }
        public async Task UpdateRequestSubtype(int requestSubtypeId, RequestSubtype updatedRequestSubtype)
        {
            var requestSubtype = await _context.RequestSubtypes.FirstOrDefaultAsync(rst => rst.RequestSubtypeID  == requestSubtypeId);
            
            requestSubtype.RequestSubtypeName = updatedRequestSubtype.RequestSubtypeName;

            _context.SaveChanges();
        }
        public async Task DeleteRequestSubtype(int requestSubtypeId)
        {
            var requestSubtype = await _context.RequestSubtypes.FirstOrDefaultAsync(rst => rst.RequestSubtypeID  == requestSubtypeId);
            if (requestSubtype == null)
            {
                throw new Exception("RequestSubtype with this id does not exist!!");
            }

            _context.RequestSubtypes.Remove(requestSubtype);
            _context.SaveChanges();
        }
    }
}