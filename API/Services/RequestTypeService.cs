using API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class RequestTypeService : IRequestTypeService
    {
        private readonly StoreContext _context;

        public RequestTypeService(StoreContext context)
        {
            _context=context;
        }

        public async Task AddRequestType(RequestType requestType)
        {
            _context.RequestTypes.Add(requestType);
            _context.SaveChanges();
        }
        public async Task<RequestType> GetRequestType(int requestTypeId)
        {
            var requestType = await _context.RequestTypes.FirstOrDefaultAsync(rt => rt.RequestTypeID  == requestTypeId);
            return requestType;
        }
        public async Task UpdateRequestType(int requestTypeId, RequestType updatedRequestType)
        {
            var requestType = await _context.RequestTypes.FirstOrDefaultAsync(rt => rt.RequestTypeID  == requestTypeId);
            
            requestType.RequestTypeName = updatedRequestType.RequestTypeName;

            _context.SaveChanges();
        }
        public async Task DeleteRequestType(int requestTypeId)
        {
            var requestType = await _context.RequestTypes.FirstOrDefaultAsync(rt => rt.RequestTypeID  == requestTypeId);
            if (requestType == null)
            {
                throw new Exception("RequestType with this id does not exist!!");
            }

            _context.RequestTypes.Remove(requestType);
            _context.SaveChanges();
        }
    }
}