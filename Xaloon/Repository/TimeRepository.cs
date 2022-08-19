using Microsoft.EntityFrameworkCore;
using Xaloon.Areas.Admin.Models;
using Xaloon.Areas.Data;
using Xaloon.Repository.IRepository;

namespace Xaloon.Repository
{
    public class TimeRepository : ITimeRepository
    {
        private readonly ApplicationDbContext _context;

        public TimeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Time time)
        {
            _context.Add(time);
            return Save();
        }

        public bool Delete(Time time)
        {
            _context.Remove(time);
            return Save();
        }

        public async Task<IEnumerable<Time>> GetAllDays()
        {
            return await _context.Times.ToListAsync();
        }

        public async Task<Time> GetDayById(int id)
        {
            return await _context.Times.FirstOrDefaultAsync(d => d.Id == id);
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Time time)
        {
            _context.Times.Update(time);
            return Save();
        }
    }
}
