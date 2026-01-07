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

        IDataResult<IList<Slots>> GetEmptySlotsByDate(DateOnly availableDate, long stationId);


        IResult AddSlot(Slots slot);
        IResult UpdateSlot(Slots slot);
        IResult DeleteSlot(Slots slot);
    }
}