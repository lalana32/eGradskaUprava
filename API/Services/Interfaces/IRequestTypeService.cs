using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Interfaces
{
    public interface IRequestTypeService
    {
        public Task AddRequestType(RequestType requestType);
        public Task<RequestType> GetRequestType(int requestTypeId);
        public Task UpdateRequestType(int requestTypeId, RequestType requestType);
        public Task DeleteRequestType(int requestTypeId);
    }
}