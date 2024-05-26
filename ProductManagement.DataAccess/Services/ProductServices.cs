using CommonLibs;
using ProductManagement.DataAccess.DBContext;
using ProductManagement.DataAccess.IServices;
using ProductManagement.DataAccess.Objects;

namespace ProductManagement.DataAccess.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ProductDBContext? productDBContext;
        public async Task<ProductSaveReturnData> Add(Product product)
        {
            var returnData = new ProductSaveReturnData();

            try
            {
                // Kiểm tra dữ liệu nhập vào
                if (product == null
                    || Validation.IsName(product.ProductName)
                    )
                {
                    returnData.ErrorCode = (int)ErrorCode.Invalid;
                    returnData.Message = "Dữ liệu đầu vào không hợp lệ";
                    return returnData;
                }

                // Kiểm tra trùng
                var currentProduct = productDBContext.Products.ToList()
                    .Where(s => s.ProductName == product.ProductName).FirstOrDefault();

                if (currentProduct != null)
                {
                    returnData.ErrorCode = (int)ErrorCode.AlreadyExist;
                    returnData.Message = "Nhân viên này đã tồn tại trên hệ thống";
                    return returnData;
                }

                // Thêm nhân viên
                productDBContext.Products.Add(product);
                returnData.ErrorCode = (int)ErrorCode.Success;
                returnData.SaveChangesCode = await productDBContext.SaveChangesAsync();
                returnData.Message = "Thêm vào cơ sở dữ liệu thành công!";
                return returnData;
            }
            catch (Exception ex)
            {
                returnData.ErrorCode = (int)ErrorCode.Exception;
                returnData.Message = ex.Message;
                return returnData;
                throw;
            }
        }

        public async Task<ProductSaveReturnData> Delete(Product product)
        {
            var returnData = new ProductSaveReturnData();

            try
            {
                // Kiểm tra dữ liệu nhập vào
                if (product.ProductID < 0
                    || product == null
                    )
                {
                    returnData.ErrorCode = (int)ErrorCode.Invalid;
                    returnData.Message = "Dữ liệu đầu vào không hợp lệ";
                    return returnData;
                }

                /* Tìm kiếm nhân viên theo ID
                var product = productDBContext.Products
                    .Where(s => s.ProductID == product.ProductID).FirstOrDefault();

                if (product == null)
                {
                    returnData.ErrorCode = (int)ErrorCode.NotExist;
                    returnData.Message = "Không tồn tại nhân viên này";
                    return returnData;
                }
                */

                // Xoá nhân viên
                productDBContext.Products.Remove(product);
                returnData.ErrorCode = (int)ErrorCode.Success;
                returnData.SaveChangesCode = await productDBContext.SaveChangesAsync();
                returnData.Message = "Thêm vào cơ sở dữ liệu thành công!";

                return returnData;
            }
            catch (Exception ex)
            {
                returnData.ErrorCode = (int)ErrorCode.Exception;
                returnData.Message = ex.Message;
                return returnData;
                throw;
            }
        }

        public List<Product> GetProducts() => [.. productDBContext.Products];

        public async Task<ProductSaveReturnData> Update(Product product)
        {
            var returnData = new ProductSaveReturnData();

            try
            {
                // Kiểm tra dữ liệu nhập vào
                if (product == null
                    || Validation.IsName(product.ProductName)
                    )
                {
                    returnData.ErrorCode = (int)ErrorCode.Invalid;
                    returnData.Message = "Dữ liệu đầu vào không hợp lệ";
                    return returnData;
                }

                productDBContext.Products.Update(product);
                returnData.ErrorCode = (int)ErrorCode.Success;
                returnData.SaveChangesCode = await productDBContext.SaveChangesAsync();
                returnData.Message = "Thêm vào cơ sở dữ liệu thành công!";

                return returnData;
            }
            catch (Exception ex)
            {
                returnData.ErrorCode = (int)ErrorCode.Exception;
                returnData.Message = ex.Message;
                return returnData;
                throw;
            }
        }
    }
}
