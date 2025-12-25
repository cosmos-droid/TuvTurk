using TuvTurk.Business.Abstract;
using TuvTurk.Business.Constants;
using TuvTurk.DataAccess.Abstract;
using TuvTurk.Entities.Concrete;
using TuvTurk.Entities.Utilities;
using IResult = TuvTurk.Entities.Utilities.IResult;

namespace TuvTurk.Business.Concrete
{
    public class EnumGroupManager : IEnumGroupService
    {
        private readonly IEnumGroupDal _enumGroupDal;

        public EnumGroupManager(IEnumGroupDal enumGroupDal)
        {
            _enumGroupDal = enumGroupDal;
        }


        public IResult AddEnumGroup(EnumGroup enumGroup)
        {
            try
            {
                _enumGroupDal.Add(enumGroup);
                return new SuccessResult(message: Messages.EnumGroupAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }

        }


        public IResult DeleteEnumGroup(EnumGroup enumGroup)
        {
            try
            {
                _enumGroupDal.Delete(enumGroup);
                return new SuccessResult(message: Messages.EnumGroupDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }


        public IDataResult<IList<EnumGroup>> GetAllEnumGroups()
        {
            try
            {
                return new SuccessDataResult<IList<EnumGroup>>(_enumGroupDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<EnumGroup>>(message: ex.Message);
            }
        }

        public IDataResult<EnumGroup> GetEnumGroupById(long EnumGroupId)
        {
            try
            {
                return new SuccessDataResult<EnumGroup>(_enumGroupDal.Get(e => e.EnumGroupId == EnumGroupId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<EnumGroup>(message: ex.Message);
            }
        }

        public IResult UpdateEnumGroup(EnumGroup enumGroup)
        {
            try
            {
                _enumGroupDal.Update(enumGroup);
                return new SuccessResult(message: Messages.EnumGroupUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }
    }



}