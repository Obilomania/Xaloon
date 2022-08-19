using Microsoft.EntityFrameworkCore;
using Xaloon.Areas.Admin.Models;
using Xaloon.Areas.Data;
using Xaloon.Repository.IRepository;

namespace Xaloon.Repository
{
    public class DayRepository : IDayRepository
    {
        private readonly ApplicationDbContext _context;

        public DayRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Day day)
        {
            _context.Add(day);
            return Save();
        }

        public bool Delete(Day day)
        {
            _context.Remove(day);
            return Save();
        }

        public async Task<IEnumerable<Day>> GetAllDays()
        {
            return await _context.Days.ToListAsync();
        }

        public async Task<Day> GetDayById(int id)
        {
            return await _context.Days.FirstOrDefaultAsync(d => d.Id == id);
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Day day)
        {
            _context.Days.Update(day);
            return Save();
        }
    }
}
