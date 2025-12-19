using TuvTurk.Business.Abstract;
using TuvTurk.Business.Constants;
using TuvTurk.DataAccess.Abstract;
using TuvTurk.Entities.Concrete;
using TuvTurk.Entities.Utilities;
using IResult = TuvTurk.Entities.Utilities.IResult;

namespace TuvTurk.Business.Concrete
{
    public class AppointmentManager : IAppointmentService
    {
        private readonly IAppointmentDal _appointmentDal;

        public AppointmentManager(IAppointmentDal appointmentDal)
        {
            _appointmentDal = appointmentDal;
        }


        public IResult AddAppointment(Appointments appointment)
        {
            try
            {
                appointment.ReservationNo = "RV" + DateTime.Now.Ticks.ToString();
                _appointmentDal.Add(appointment);
                return new SuccessResult(message: Messages.AppointmentAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }

        public IResult DeleteAppointment(Appointments appointment)
        {
            try
            {
                _appointmentDal.Delete(appointment);
                return new SuccessResult(message: Messages.AppointmentDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }

        }

        public IDataResult<IList<Appointments>> GetAllAppointments()
        {
            try
            {
                return new SuccessDataResult<IList<Appointments>>(_appointmentDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<Appointments>>(message: ex.Message);
            }
        }

        public IDataResult<Appointments> GetAppointmentById(long AppointmentId)
        {
            try
            {
                return new SuccessDataResult<Appointments>(_appointmentDal.Get(q => q.AppointmentID == AppointmentId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Appointments>(message: ex.Message);
            }
        }

        public IResult UpdateAppointment(Appointments appointment)
        {
            try
            {
                _appointmentDal.Update(appointment);
                return new SuccessResult(message: Messages.AppointmentUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }
    }
}