using StudentManager.DataAccess.Objects;

namespace StudentManager.DataAccess.IServices
{
    public interface IStudentServices
    {
        Task<StudentSaveChangesReturnData> Insert(Student student);
        Task<StudentSaveChangesReturnData> Update(Student student);
        Task<StudentSaveChangesReturnData> Delete(Student student);
        Task<StudentSearchReturnData> GetById(int id);
        Task<StudentSearchReturnData> GetByName(string name);
        Task<List<StudentSearchReturnData>> GetAll();
    }
}
