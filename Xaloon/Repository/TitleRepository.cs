using Microsoft.EntityFrameworkCore;
using Xaloon.Areas.Admin.Models;
using Xaloon.Areas.Data;
using Xaloon.Repository.IRepository;

namespace Xaloon.Repository
{
    public class TitleRepository : ITitleRepository
    {
        private readonly ApplicationDbContext _context;

        public TitleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Title title)
        {
            _context.Add(title);
            return Save();
        }

        public bool Delete(Title title)
        {
            _context.Remove(title);
            return Save();
        }

        public async Task<IEnumerable<Title>> GetAllTitles()
        {
            return await _context.Titles.ToListAsync();
        }

        public async Task<Title> GetDayById(int id)
        {
            return await _context.Titles.FirstOrDefaultAsync(d => d.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Title title)
        {
            _context.Titles.Update(title);
            return Save();
        }
    }
}
