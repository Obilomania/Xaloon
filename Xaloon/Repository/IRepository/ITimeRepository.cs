using Xaloon.Areas.Admin.Models;

namespace Xaloon.Repository.IRepository
{
    public interface ITimeRepository
    {
        Task<IEnumerable<Time>> GetAllDays();
        Task<Time> GetDayById(int id);
        bool Add(Time time);
        bool Update(Time time);
        bool Delete(Time time);
        bool Save();
    }
}
