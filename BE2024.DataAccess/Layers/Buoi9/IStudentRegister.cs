using BE2024.DataAccess.Objects;
using CommonLibs;

namespace BE2024.DataAccess.Layers
{
    internal interface IStudentRegister
    {
        ReturnData Register(Student student);
    }
}
