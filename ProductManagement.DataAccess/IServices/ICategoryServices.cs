using ProductManagement.DataAccess.Objects;

namespace ProductManagement.DataAccess.IServices
{
    public interface ICategoryServices
    {
        List<Category> GetAll();
        Task<SaveChangesReturnData> Add(Category category);
        Task<SaveChangesReturnData> Update(Category category);
        Task<SaveChangesReturnData> Delete(Category category);
    }
}
