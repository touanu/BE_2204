using ProductManagement.DataAccess.Objects;

namespace ProductManagement.DataAccess.IServices
{
    public interface ICategoryServices
    {
        List<Category> GetAll();
        Task<SaveChangesReturnData> Add(CategoryAddRequest category);
        Task<SaveChangesReturnData> Update(CategoryUpdateRequest category);
        Task<SaveChangesReturnData> Delete(CategoryDeleteRequest category);
    }
}
