using CommonLibs;

namespace StudentManager.DataAccess.Objects
{
    public class StudentSaveChangesReturnData : ReturnData
    {
        public int PlaceCode { get; set; }
    }

    public class StudentSearchReturnData : ReturnData
    {
        public Student? FoundStudent { get; set; }
    }
}
