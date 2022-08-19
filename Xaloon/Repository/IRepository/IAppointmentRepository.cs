using Xaloon.Areas.Customer.Models;

namespace Xaloon.Repository.IRepository
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAll();
        Task<Appointment> GetById(int id);
        bool Add(Appointment appointment);
        bool Update(Appointment appointment);
        bool Delete(Appointment appointment);
        bool Save();
    }
}
