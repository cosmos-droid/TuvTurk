using TuvTurk.Business.Abstract;
using TuvTurk.Business.Constants;
using TuvTurk.DataAccess.Abstract;
using TuvTurk.Entities.Concrete;
using TuvTurk.Entities.Utilities;
using IResult = TuvTurk.Entities.Utilities.IResult;

namespace TuvTurk.Business.Concrete
{
    public class SlotManager : ISlotService
    {
        private readonly ISlotDal _slotDal;

        public SlotManager(ISlotDal slotDal)
        {
            _slotDal = slotDal;
        }

        public IResult AddSlot(Slots slot)
        {
            try
            {
                _slotDal.Add(slot);
                return new SuccessResult(message: Messages.SlotAdded);
            }
            catch (Exception ex)
            {

                return new ErrorResult(message: ex.Message);
            }
        }

        public IResult DeleteSlot(Slots slot)
        {
            try
            {
                _slotDal.Delete(slot);
                return new SuccessResult(message: Messages.SlotDeleted);
            }
            catch (Exception ex)
            {

                return new ErrorResult(message: ex.Message);
            }
        }
        public IResult UpdateSlot(Slots slot)
        {
            try
            {
                _slotDal.Update(slot);
                return new SuccessResult(message: Messages.SlotUpdated);
            }
            catch (Exception ex)
            {

                return new ErrorResult(message: ex.Message);
            }
        }



        public IResult GetAndUpdateSlot(long appointmentId, long stationId, DateOnly availableDate, long appointmentSlot)
        {
            try
            {
                Slots tempSlot = _slotDal.Get(q => q.StationId == stationId && q.AvailableDate == availableDate && q.AppointmentSlot == appointmentSlot);
                tempSlot.AppointmentId = appointmentId;
                UpdateSlot(tempSlot);
                return new SuccessResult(message: Messages.SlotUpdated);
            }
            catch (Exception ex)
            {

                return new ErrorResult(message: ex.Message);
            }
        }

        public IDataResult<IList<Slots>> GetAllSlots()
        {
            try
            {
                return new SuccessDataResult<IList<Slots>>(_slotDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<Slots>>(message: ex.Message);
            }
        }

        public IDataResult<Slots> GetSlotById(long SlotId)
        {
            try
            {
                return new SuccessDataResult<Slots>(_slotDal.Get(q => q.SlotId == SlotId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Slots>(message: ex.Message);
            }
        }


        //Endpoint for frontend widget
        public IDataResult<IList<Slots>> GetEmptySlots(long stationId)
        {
            try
            {
                return new SuccessDataResult<IList<Slots>>(_slotDal.GetAll(q => q.AppointmentId == null && q.StationId == stationId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<Slots>>(message: ex.Message);
            }
        }

        public IDataResult<IList<Slots>> GetEmptySlotsByDate(DateOnly availableDateStart, DateOnly availableDateEnd, long stationId)
        {
            try
            {
                return new SuccessDataResult<IList<Slots>>(_slotDal.GetAll(q => q.AvailableDate >= availableDateStart &&
                q.AvailableDate <= availableDateEnd &&
                q.AppointmentId == null &&
                q.StationId == stationId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<Slots>>(message: ex.Message);
            }
        }

        public IDataResult<IList<KeyValuePair<string, float>>> CalculateOccupancy(long stationId)
        {
            try
            {
                IList<KeyValuePair<string, float>> DateOccupancyRates = new List<KeyValuePair<string, float>>();
                string minDate = _slotDal.GetAll(q => q.StationId == stationId).Min(s => s.AvailableDate).ToString();
                string maxDate = _slotDal.GetAll(q => q.StationId == stationId).Max(s => s.AvailableDate).ToString();

                IList<string> dateList = _slotDal.GetAll(q => q.StationId == stationId && q.AvailableDate >= DateOnly.Parse(minDate) && q.AvailableDate <= DateOnly.Parse(maxDate))
                    .Select(s => s.AvailableDate.ToString()).Distinct().ToList();


                foreach (string date in dateList)
                {
                    float nonOccupiedSlots = GetEmptySlotsByDate(DateOnly.Parse(date), DateOnly.Parse(date), stationId).Data.Count;
                    float occupiedSlots = _slotDal.GetAll(q => q.StationId == stationId && q.AvailableDate == DateOnly.Parse(date) && q.AppointmentId != null).Count;
                    float occupationRate = occupiedSlots * (100 / (nonOccupiedSlots + occupiedSlots)) / ((nonOccupiedSlots + occupiedSlots) * (100 / (nonOccupiedSlots + occupiedSlots)));
                    DateOccupancyRates.Add(new KeyValuePair<string, float>(date, occupationRate * 100));
                }

                // float nonOccupiedSlots = GetEmptySlotsByDate(availableDateStart, availableDateEnd, stationId).Data.Count;
                // float occupiedSlots = _slotDal.GetAll(q => q.AvailableDate >= availableDateStart && q.AvailableDate <= availableDateEnd && q.AppointmentId != null).Count;



                // float occupationRate = occupiedSlots * (100 / (nonOccupiedSlots + occupiedSlots)) / ((nonOccupiedSlots + occupiedSlots) * (100 / (nonOccupiedSlots + occupiedSlots)));


                return new SuccessDataResult<IList<KeyValuePair<string, float>>>(DateOccupancyRates);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<KeyValuePair<string, float>>>(message: ex.Message);
            }

        }
    }
}