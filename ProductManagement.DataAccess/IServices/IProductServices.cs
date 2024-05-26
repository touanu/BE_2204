using ProductManagement.DataAccess.Objects;

namespace ProductManagement.DataAccess.IServices
{
    public interface IProductServices
    {
        List<GetProductReturnData> GetProducts();
        Task<SaveChangesReturnData> Add(ProductAddRequest product);
        Task<SaveChangesReturnData> Update(ProductUpdateRequest product);
        Task<SaveChangesReturnData> Delete(ProductDeleteRequest product);
    }
}
