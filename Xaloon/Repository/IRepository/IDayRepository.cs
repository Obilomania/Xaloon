using Xaloon.Areas.Admin.Models;

namespace Xaloon.Repository.IRepository
{
    public interface IDayRepository
    {
        Task<IEnumerable<Day>> GetAllDays();
        Task<Day> GetDayById(int id);
        bool Add(Day day);
        bool Update(Day day);
        bool Delete(Day day);
        bool Save();
    }
}
