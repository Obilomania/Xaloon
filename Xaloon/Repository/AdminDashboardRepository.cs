using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Xaloon.Areas.Customer.Models;
using Xaloon.Areas.Data;
using Xaloon.Repository.IRepository;

namespace Xaloon.Repository
{
    public class AdminDashboardRepository : IAdminDashboardRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public AdminDashboardRepository(ApplicationDbContext context, IHttpContextAccessor contextAccessor)
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
            _context.Remove(appointment);
            return Save();
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            return await _context.Appointments.Include(a => a.Booker)
                                              .Include(a => a.Day)
                                              .Include(a => a.Time)
                                              .Include(a => a.Title)
                                              .ToListAsync();
        } 

        public async Task<Appointment> GetById(int id)
        {
            return await _context.Appointments.Where(a => a.Id == id)
                            .Include(a => a.Day)
                            .Include(a => a.Title)
                            .Include(a => a.Time)
                            .Include(a => a.Booker)
                            .FirstOrDefaultAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Appointment appointment)
        {
            _context.Update(appointment);
            return Save();
        }
    }
}
