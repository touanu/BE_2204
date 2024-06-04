using CommonLibs;
using ProductManagement.DataAccess.DBContext;
using ProductManagement.DataAccess.IServices;
using ProductManagement.DataAccess.Objects;
using System.Collections.Generic;

namespace ProductManagement.DataAccess.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ProductDBContext productDBContext = new();
        public async Task<SaveChangesReturnData> Add(ProductInsertUpdateRequestData requestData)
        {
            var returnData = new SaveChangesReturnData();
            var errItem = string.Empty;

            try
            {
                if (requestData == null
                    || requestData.CategoryId == 0
                    || Validation.IsName(requestData.ProductName)
                    || string.IsNullOrEmpty(requestData.AttributeValues)
                    || !Validation.IsContainSpecialCharacters(requestData.AttributeValues)
                    || !Validation.IsContainHTMLTags(requestData.AttributeValues)
                    )    
                {
                    returnData.ErrorCode = (int)ErrorCode.Invalid;
                    returnData.Message = "Dữ liệu không hợp lệ";
                    return returnData;
                }

                // Kiểm tra trùng
                var currentProduct = productDBContext.Products.ToList()
                    .Where(s => s.ProductName == requestData.ProductName).FirstOrDefault();

                if (currentProduct != null)
                {
                    returnData.ErrorCode = (int)ErrorCode.AlreadyExist;
                    returnData.Message = "Sản phẩm này đã tồn tại trên hệ thống";
                    return returnData;
                }

                // Thêm sản phẩm
                var productReq = new Product
                {
                    ProductName = requestData.ProductName,
                    CategoryID = requestData.CategoryId
                };
                productDBContext.Products.Add(productReq);


                var attr_count = requestData.AttributeValues.Split('_').Length;

                for (int i = 0; i < attr_count; i++)
                {
                    var item = requestData.AttributeValues.Split('_')[i];

                    var attr_name = item.Split(',')[0];
                    var attr_quantity = item.Split(',')[1];

                    var attr_price = item.Split(',')[2];
                    var attr_priceSale = item.Split(',')[3];

                    // kiểm tra xem null 

                    if (string.IsNullOrEmpty(attr_name))
                    {
                        errItem += "Tên thuộc tính bị trống hoặc không hợp lệ";
                        continue;
                    }

                    if (string.IsNullOrEmpty(attr_quantity))
                    {
                        errItem += "Thuộc tính số lượng bị trống";
                        continue;
                    }

                    if (string.IsNullOrEmpty(attr_price))
                    {
                        errItem += "Thuộc tính giá bị trống";
                        continue;
                    }

                    if (string.IsNullOrEmpty(attr_priceSale))
                    {
                        errItem += "Thuộc tính giá sale bị trống";
                        continue;
                    }

                    var attr_Req = new GroupAttribute
                    {
                        AttributeName = attr_name,
                        Quantity = Convert.ToInt32(attr_quantity),
                        Price = Convert.ToInt32(attr_price),
                        PriceSale = Convert.ToInt32(attr_priceSale),
                    };

                    productDBContext.Add(attr_Req);
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
            }
        }

        public async Task<SaveChangesReturnData> Delete(ProductDeleteRequestData requestData)
        {
            var returnData = new SaveChangesReturnData();

            try
            {
                // Tìm kiếm sản phẩm theo ID
                var currentProduct = productDBContext.Products
                    .Where(s => s.ProductID == requestData.ProductID).FirstOrDefault();

                if (currentProduct == null)
                {
                    returnData.ErrorCode = (int)ErrorCode.NotExist;
                    returnData.Message = "Không tồn tại sản phẩm này";
                    return returnData;
                }

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
            }
        }

        public List<Product> GetProducts()
        {
            var returnData = new List<Product>();

            if (!productDBContext.Products.Any())
                return returnData;

            var listProduct = productDBContext.Products.ToList();
            foreach (var item in listProduct)
            {
                // lấy attribute theo productId 
                var p_attr = productDBContext.GroupAttributes
                    .ToList().FindAll(x => x.ProductID == item.ProductID);

                var product = new Product
                {
                    ProductAttributes = p_attr,
                    ProductID = item.ProductID,
                    ProductName = item.ProductName
                };

                returnData.Add(product);

            }

            return returnData;
        }

        public Task<SaveChangesReturnData> Update(ProductInsertUpdateRequestData requestData)
        {
            throw new NotImplementedException();
        }

                /*
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
        */
    }
}
