using Microsoft.EntityFrameworkCore.Storage;
using TuvTurk.Entities.Concrete;
using TuvTurk.Entities.Utilities;
using IResult = TuvTurk.Entities.Utilities.IResult;

namespace TuvTurk.Business.Abstract
{
    public interface ISlotService
    {
        IDataResult<Slots> GetSlotById(long SlotId);
        IDataResult<IList<Slots>> GetAllSlots();
        IDataResult<IList<Slots>> GetEmptySlots(long stationId);

        IDataResult<IList<Slots>> GetEmptySlotsByDate(DateOnly availableDateStart, DateOnly availableDateEnd, long stationId);

        IDataResult<float> CalculateOccupancy(DateOnly availableDateStart, DateOnly availableDateEnd, long stationId);

        IResult GetAndUpdateSlot(long appointmentId,long stationId, DateOnly availableDate, long AppointmentSlot);


        IResult AddSlot(Slots slot);
        IResult UpdateSlot(Slots slot);
        IResult DeleteSlot(Slots slot);
    }
}