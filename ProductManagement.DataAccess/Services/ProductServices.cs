using CommonLibs;
using ProductManagement.DataAccess.DBContext;
using ProductManagement.DataAccess.IServices;
using ProductManagement.DataAccess.Objects;

namespace ProductManagement.DataAccess.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ProductDBContext productDBContext = new();
        public async Task<SaveChangesReturnData> Add(ProductAddRequest product)
        {
            var returnData = new SaveChangesReturnData();

            try
            {
                // Kiểm tra dữ liệu nhập vào
                bool isVariantInvalid = product.Variants == null
                        || product.Variants.Exists(item => item.VariantID < 0)
                        || product.Variants.Exists(item => item.VariantType < 0)
                        || product.Variants.Exists(item => Validation.IsContainHTMLTags(item.VariantDescription))
                        || product.Variants.Exists(item => item.ProductID == product.Product.ProductID);

                if (product == null
                    || isVariantInvalid
                    || Validation.IsName(product.Product.ProductName)
                    )
                {
                    returnData.ErrorCode = (int)ErrorCode.Invalid;
                    returnData.Message = "Dữ liệu đầu vào không hợp lệ";
                    return returnData;
                }

                // Kiểm tra trùng
                var currentProduct = productDBContext.Products.ToList()
                    .Where(s => s.ProductName == product.Product.ProductName).FirstOrDefault();

                if (currentProduct != null)
                {
                    returnData.ErrorCode = (int)ErrorCode.AlreadyExist;
                    returnData.Message = "Sản phẩm này đã tồn tại trên hệ thống";
                    return returnData;
                }

                // Thêm sản phẩm
                productDBContext.Products.Add(product.Product);

                if (product.Variants != null)
                    foreach (var item in product.Variants)
                        productDBContext.ProductVariants.Add(item);

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

        public async Task<SaveChangesReturnData> Delete(ProductDeleteRequest product)
        {
            var returnData = new SaveChangesReturnData();

            try
            {
                // Kiểm tra dữ liệu nhập vào
                if (product.ProductId < 0
                    || product.VariantId < 0
                    || product == null
                    )
                {
                    returnData.ErrorCode = (int)ErrorCode.Invalid;
                    returnData.Message = "Dữ liệu đầu vào không hợp lệ";
                    return returnData;
                }

                // Tìm kiếm sản phẩm theo ID
                var currentProduct = productDBContext.Products
                    .Where(s => s.ProductID == product.ProductId).FirstOrDefault();

                if (currentProduct == null)
                {
                    returnData.ErrorCode = (int)ErrorCode.NotExist;
                    returnData.Message = "Không tồn tại sản phẩm này";
                    return returnData;
                }

                // Xoá cả sản phẩm
                if (product.VariantId == null)
                {
                    productDBContext.Products.Remove(currentProduct);
                    returnData.ErrorCode = (int)ErrorCode.Success;
                    returnData.SaveChangesCode = await productDBContext.SaveChangesAsync();
                    returnData.Message = "Xoá thành công!";
                    return returnData;
                }

                // Chỉ xoá một biến thể của sản phẩm
                var currentVariant = productDBContext.ProductVariants
                    .Where(s => s.VariantID == product.VariantId).FirstOrDefault();

                if (currentVariant == null)
                {
                    returnData.ErrorCode = (int)ErrorCode.NotExist;
                    returnData.Message = "Không tồn tại biến thể này của sản phẩm";
                    return returnData;
                }

                productDBContext.ProductVariants.Remove(currentVariant);
                returnData.ErrorCode = (int)ErrorCode.Success;
                returnData.SaveChangesCode = await productDBContext.SaveChangesAsync();
                returnData.Message = "Xoá thành công";
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

        public List<GetProductReturnData> GetProducts()
        {
            var returnData = new List<GetProductReturnData>();

            if (!productDBContext.Products.Any())
                return returnData;

            /* Khi trả về dữ liệu, Variants cần phải khớp với Product
             * bằng cách so sánh ProductID
             */
            foreach (var item in productDBContext.Products.ToList())
            {
                var variants = productDBContext.ProductVariants
                    .Where(s => s.ProductID == item.ProductID)
                    .ToList();
                
                returnData.Add(
                    new GetProductReturnData(item, variants)
                );
            }

            return returnData;
        }

        public async Task<SaveChangesReturnData> Update(ProductUpdateRequest product)
        {
            var returnData = new SaveChangesReturnData();

            try
            {
                // Kiểm tra dữ liệu nhập vào
                bool isVariantInvalid = false;
                if (product.Variants != null)
                {
                    isVariantInvalid = product.Variants.Exists(item => item.VariantID < 0)
                            || product.Variants.Exists(item => item.VariantType < 0)
                            || product.Variants.Exists(item => Validation.IsContainHTMLTags(item.VariantDescription))
                            || product.Variants.Exists(item => item.ProductID == product.Product.ProductID);
                }
                if (product == null
                    || isVariantInvalid
                    || Validation.IsName(product.Product.ProductName)
                    )
                {
                    returnData.ErrorCode = (int)ErrorCode.Invalid;
                    returnData.Message = "Dữ liệu đầu vào không hợp lệ";
                    return returnData;
                }

                // Kiểm tra tồn tại
                var currentProduct = productDBContext.Products.ToList()
                    .Where(s => s.ProductName == product.Product.ProductName).FirstOrDefault();

                if (currentProduct == null)
                {
                    returnData.ErrorCode = (int)ErrorCode.NotExist;
                    returnData.Message = "Sản phẩm này không tồn tại trên hệ thống";
                    return returnData;
                }

                // Cập nhật cơ sở dữ liệu
                productDBContext.Products.Update(product.Product);

                //      Một sản phẩm phải có ít nhất 1 biến thể
                var productVariants = productDBContext.ProductVariants
                    .Where(s => s.ProductID == product.Product.ProductID);
                if (productVariants.Count() <= 1)
                {
                    returnData.ErrorCode = (int)ErrorCode.MinimumRequired;
                    returnData.Message = "Cần phải có ít nhất 1 biến thể cho sản phẩm";
                    return returnData;
                }

                if (product.Variants != null)
                    foreach (var item in product.Variants)
                    {
                        if (!productDBContext.ProductVariants
                            .Any(s => s.VariantID == item.VariantID))
                        {
                            productDBContext.ProductVariants.Add(item);
                            continue;
                        }

                        productDBContext.ProductVariants.Update(item);
                    }

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
