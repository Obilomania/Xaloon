using Microsoft.EntityFrameworkCore;
using Xaloon.Areas.Admin.Models;
using Xaloon.Areas.Customer.Models;
using Xaloon.Areas.Data;
using Xaloon.Repository.IRepository;

namespace Xaloon.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
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

        public async Task<IEnumerable<Appointment>> GetAll()
        {
            return await _context.Appointments.ToListAsync();
        }

        public Task<Appointment> GetById(int id)
        {
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
