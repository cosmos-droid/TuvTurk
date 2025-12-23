using TuvTurk.Business.Abstract;
using TuvTurk.Business.Constants;
using TuvTurk.DataAccess.Abstract;
using TuvTurk.Entities.Concrete;
using TuvTurk.Entities.Utilities;
using IResult = TuvTurk.Entities.Utilities.IResult;

namespace TuvTurk.Business.Concrete
{
    public class EnumGroupTypeManager : IEnumGroupTypeService
    {
        private readonly IEnumGroupTypeDal _enumGroupTypeDal;

        public EnumGroupTypeManager(IEnumGroupTypeDal enumGroupTypeDal)
        {
            _enumGroupTypeDal = enumGroupTypeDal;
        }

        public IResult AddEnumGroupType(EnumGroupType enumGroupType)
        {
            try
            {
                _enumGroupTypeDal.Add(enumGroupType);
                return new SuccessResult(message: Messages.EnumGroupTypeAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }

        public IResult DeleteEnumGroupType(EnumGroupType enumGroupType)
        {
            try
            {
                _enumGroupTypeDal.Delete(enumGroupType);
                return new SuccessResult(message: Messages.EnumGroupTypeDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }

        public IDataResult<IList<EnumGroupType>> GetAllEnumGroupTypes()
        {
            try
            {
                return new SuccessDataResult<IList<EnumGroupType>>(_enumGroupTypeDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<EnumGroupType>>(message: ex.Message);
            }
        }

        public IDataResult<EnumGroupType> GetEnumGroupTypeById(long EnumGroupTypeId)
        {
            try
            {
                return new SuccessDataResult<EnumGroupType>(_enumGroupTypeDal.Get(e => e.EnumGroupTypeId == EnumGroupTypeId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<EnumGroupType>(message: ex.Message);
            }
        }

        public IResult UpdateEnumGroupType(EnumGroupType enumGroupType)
        {
            try
            {
                _enumGroupTypeDal.Update(enumGroupType);
                return new SuccessResult(message: Messages.EnumGroupTypeUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }
    }



}