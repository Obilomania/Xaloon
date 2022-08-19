using Microsoft.EntityFrameworkCore;
using Xaloon.Areas.Customer.Models;
using Xaloon.Areas.Data;
using Xaloon.Repository.IRepository;
using Xaloon.Utility;

namespace Xaloon.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;


        public AppointmentRepository(ApplicationDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public bool Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            return Save();
        }

        public bool Delete(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
            return Save();
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            var curUser = _contextAccessor.HttpContext?.User.GetUserId();
            return await _context.Appointments.Where(a => a.Booker.Id == curUser)
                                                        .Include(a => a.Day)
                                                        .Include(a => a.Time)
                                                        .Include(a => a.Title).ToListAsync();

            //return await _context.Appointments.Include(a => a.Day)
            //                     .Include(a => a.Time)
            //                     .Include(a => a.Title).ToListAsync();
        }

        public Task<Appointment> GetById(int id)
        {
            var curUser = _contextAccessor.HttpContext?.User.GetUserId();
            return _context.Appointments.Where(a => a.Id == id)
                            .Include(a => a.Day)
                            .Include(a => a.Title)
                            .Include(a => a.Time)
                            .FirstOrDefaultAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            return Save();
        }
    }
}
