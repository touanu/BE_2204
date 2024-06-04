using ProductManagement.DataAccess.Objects;

namespace ProductManagement.DataAccess.IServices
{
    public interface IProductServices
    {
        List<Product> GetProducts();
        Task<SaveChangesReturnData> Add(ProductInsertUpdateRequestData requestData);
        Task<SaveChangesReturnData> Update(ProductInsertUpdateRequestData requestData);
        Task<SaveChangesReturnData> Delete(ProductDeleteRequestData requestData);
    }
}
