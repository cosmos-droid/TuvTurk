
using TuvTurk.Entities.Concrete;
using TuvTurk.Entities.Utilities;
using IResult = TuvTurk.Entities.Utilities.IResult;

namespace TuvTurk.Business.Abstract
{
    public interface IEnumGroupService
    {
        IDataResult<EnumGroup> GetEnumGroupById(long EnumGroupId);
        IDataResult<IList<EnumGroup>> GetAllEnumGroups();

        IResult AddEnumGroup(EnumGroup enumGroup);
        IResult UpdateEnumGroup(EnumGroup enumGroup);
        IResult DeleteEnumGroup(EnumGroup enumGroup);


    }
}