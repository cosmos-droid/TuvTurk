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

    }
}