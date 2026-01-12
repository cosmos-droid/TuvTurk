using TuvTurk.Entities.Concrete;
using TuvTurk.Entities.Utilities;
using IResult = TuvTurk.Entities.Utilities.IResult;

namespace TuvTurk.Business.Abstract
{
    public interface IEnumGroupTypeService
    {
        IDataResult<EnumGroupType> GetEnumGroupTypeById(long EnumGroupTypeId);

        IDataResult<IList<EnumGroupType>> GetEnumGroupTypeByEnumGroupId(long enumGroupId);


        IDataResult<IList<EnumGroupType>> GetAllEnumGroupTypes();

        IResult AddEnumGroupType(EnumGroupType enumGroupType);
        IResult UpdateEnumGroupType(EnumGroupType enumGroupType);
        IResult DeleteEnumGroupType(EnumGroupType enumGroupType);


    }
}