using ProductManagement.DataAccess.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.DataAccess.IServices
{
    public interface IProductServices
    {
        List<Product> GetProducts();
        Task<ProductSaveReturnData> Add(Product product);
        Task<ProductSaveReturnData> Update(Product product);
        Task<ProductSaveReturnData> Delete(Product product);
    }
}
