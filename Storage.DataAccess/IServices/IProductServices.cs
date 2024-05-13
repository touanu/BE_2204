using Storage.DataAccess.Objects;

namespace Storage.DataAccess.IServices
{
    internal interface IProductServices
    {
        Task<ProductInsertReturnData> ProductInsert(Product product);
        Task<Product> GetProduct(string searchValue);
    }
}
