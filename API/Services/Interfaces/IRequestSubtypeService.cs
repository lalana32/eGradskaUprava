using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Interfaces
{
    public interface IRequestSubtypeService
    {
        public Task AddRequestSubtype(RequestSubtype requestSubtype);
        public Task<RequestSubtype> GetRequestSubtype(int requestSubtypeId);
        public Task UpdateRequestSubtype(int requestSubtypeId, RequestSubtype updatedRequestSubtype);
        public Task DeleteRequestSubtype(int requestSubtypeId);
    }
}