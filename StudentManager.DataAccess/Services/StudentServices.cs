using StudentManager.DataAccess.IServices;
using StudentManager.DataAccess.Objects;

namespace StudentManager.DataAccess.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly List<Student> _students;
        public Task<StudentSaveChangesReturnData> Delete(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentSearchReturnData>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<StudentSearchReturnData> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<StudentSearchReturnData> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<StudentSaveChangesReturnData> Insert(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<StudentSaveChangesReturnData> Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
