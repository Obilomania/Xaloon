using Xaloon.Areas.Customer.Models;

namespace Xaloon.Repository.IRepository
{
    public interface IDashboardRepository
    {
        Task<List<Appointment>> GetAll();
    }
}
