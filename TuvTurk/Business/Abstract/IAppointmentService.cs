
using TuvTurk.Entities.Concrete;
using TuvTurk.Entities.Utilities;
using IResult = TuvTurk.Entities.Utilities.IResult;

namespace TuvTurk.Business.Abstract
{
    public interface IAppointmentService
    {
        IDataResult<Appointments> GetAppointmentById(long AppointmentId);
       
        IDataResult<Appointments> GetAppointmentByReservationNo(string reservationno);
      
        IDataResult<IList<Appointments>> GetAllAppointments();

        IResult AddAppointment(Appointments appointment);
        IResult UpdateAppointment(Appointments appointment);
        IResult DeleteAppointment(Appointments appointment);


    }
}