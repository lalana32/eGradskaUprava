using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Interfaces
{
    public interface IAppointmentTypeService
    {
        public Task AddAppointmentType(AppointmentType appointmentType);
        public Task<AppointmentType> GetAppointmentType(int appointmentTypeId);
        public Task<List<AppointmentType>> GetAllAppointmentTypes();
        public Task UpdateAppointmentType(int appointmenTypetId, AppointmentType updatedAppointmentType);
        public Task DeleteAppointmentType(int appointmentTypeId);
    }
}