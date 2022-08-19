using Xaloon.Areas.Admin.Models;

namespace Xaloon.Repository.IRepository
{
    public interface ITitleRepository
    {
        Task<IEnumerable<Title>> GetAllDays();
        Task<Title> GetDayById(int id);
        bool Add(Title title);
        bool Update(Title title);
        bool Delete(Title title);
        bool Save();
    }
}
