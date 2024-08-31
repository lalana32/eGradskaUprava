using API.Services.Interfaces;
using API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace API.Services
{
    public class AppointmentTypeService : IAppointmentTypeService
    {
        
        private readonly StoreContext _context;

        public AppointmentTypeService(StoreContext context)
        {
            _context=context;
        }

        public async Task AddAppointmentType(AppointmentType appointmentType)
        {
            _context.AppointmentTypes.Add(appointmentType);
            _context.SaveChanges();
        }
        public async Task<AppointmentType> GetAppointmentType(int appointmentTypeId)
        {
            var appointmentType = await _context.AppointmentTypes.FirstOrDefaultAsync(at => at.AppointmentTypeID  == appointmentTypeId);
            return appointmentType;
        }

        public async Task<List<AppointmentType>> GetAllAppointmentTypes()
        {
            var appointmentTypes = await _context.AppointmentTypes.ToListAsync();

            return appointmentTypes;
        }
        public async Task UpdateAppointmentType(int appointmentTypeId, AppointmentType updatedAppointmentType)
        {
            var appointmentType = await _context.AppointmentTypes.FirstOrDefaultAsync(at => at.AppointmentTypeID  == appointmentTypeId);
            
            appointmentType.AppointmentTypeName = updatedAppointmentType.AppointmentTypeName;

            _context.SaveChanges();
        }
        public async Task DeleteAppointmentType(int appointmentTypeId)
        {
            var appointmentType = await _context.AppointmentTypes.FirstOrDefaultAsync(at => at.AppointmentTypeID  == appointmentTypeId);
            if (appointmentType == null)
            {
                throw new Exception("AppointmentType with this id does not exist!!");
            }

            _context.AppointmentTypes.Remove(appointmentType);
            _context.SaveChanges();
        }

        
        
    }
}