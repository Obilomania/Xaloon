using Xaloon.Areas.Customer.Models;
using Xaloon.Areas.Data;
using Xaloon.Repository.IRepository;
using Xaloon.Utility;

namespace Xaloon.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public async Task<List<Appointment>> GetAll()
        {
            var curUser = _contextAccessor.HttpContext?.User.GetUserId();
            var userAppointment = _context.Appointments.Where(a => a.Booker.Id == curUser);
            return userAppointment.ToList();
        }
    }
}
