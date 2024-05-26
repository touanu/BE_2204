using CommonLibs;
using ProductManagement.DataAccess.DBContext;
using ProductManagement.DataAccess.IServices;
using ProductManagement.DataAccess.Objects;

namespace ProductManagement.DataAccess.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ProductDBContext productDBContext = new();

        public async Task<SaveChangesReturnData> Add(CategoryAddRequest category)
        {
            var returnData = new SaveChangesReturnData();

            try
            {
                // Kiểm tra dữ liệu nhập vào
                if (category == null
                    || Validation.IsName(category.Category.CategoryName)
                    )
                {
                    returnData.ErrorCode = (int)ErrorCode.Invalid;
                    returnData.Message = "Dữ liệu đầu vào không hợp lệ";
                    return returnData;
                }

                // Kiểm tra trùng
                var currentProduct = productDBContext.Categories.ToList()
                    .Where(s => s.CategoryName == category.Category.CategoryName).FirstOrDefault();

                if (currentProduct != null)
                {
                    returnData.ErrorCode = (int)ErrorCode.AlreadyExist;
                    returnData.Message = "Nhân viên này đã tồn tại trên hệ thống";
                    return returnData;
                }

                // Thêm danh mục
                productDBContext.Categories.Add(category.Category);
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

        public async Task<SaveChangesReturnData> Delete(CategoryDeleteRequest category)
        {
            var returnData = new SaveChangesReturnData();

            try
            {
                // Kiểm tra dữ liệu nhập vào
                if (category.CategoryId < 0
                    || category.CDId < 0
                    || category == null
                    )
                {
                    returnData.ErrorCode = (int)ErrorCode.Invalid;
                    returnData.Message = "Dữ liệu đầu vào không hợp lệ";
                    return returnData;
                }

                // Tìm kiếm sản phẩm theo ID
                var currentCategory = productDBContext.Categories
                    .Where(s => s.CategoryId == category.CategoryId).FirstOrDefault();

                if (currentCategory == null)
                {
                    returnData.ErrorCode = (int)ErrorCode.NotExist;
                    returnData.Message = "Không tồn tại sản phẩm này";
                    return returnData;
                }

                // Xoá cả sản phẩm
                if (category.CDId == null)
                {
                    productDBContext.Categories.Remove(currentCategory);
                    returnData.ErrorCode = (int)ErrorCode.Success;
                    returnData.SaveChangesCode = await productDBContext.SaveChangesAsync();
                    returnData.Message = "Xoá thành công!";
                    return returnData;
                }

                // Chỉ xoá một danh mục khỏi sản phẩm
                var currentCategoryDetail = productDBContext.CategoryDetails
                    .Where(
                        s => s.CDID == category.CDId
                        && s.CategoryID == category.CategoryId
                    ).FirstOrDefault();

                if (currentCategoryDetail == null)
                {
                    returnData.ErrorCode = (int)ErrorCode.NotExist;
                    returnData.Message = "Sản phẩm không tồn tại danh mục này";
                    return returnData;
                }

                productDBContext.CategoryDetails.Remove(currentCategoryDetail);
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

        public List<Category> GetAll()
        {
            return [.. productDBContext.Categories];
        }

        public async Task<SaveChangesReturnData> Update(CategoryUpdateRequest category)
        {
            var returnData = new SaveChangesReturnData();

            try
            {
                // Kiểm tra dữ liệu nhập vào
                bool isCategoryInvalid = false;
                if (category.Details != null)
                {
                    isCategoryInvalid = category.Details.Exists(item => item.CDID < 0)
                            || category.Details.Exists(item => item.CategoryID == category.Category.CategoryId);
                }
                if (category == null
                    || isCategoryInvalid
                    || Validation.IsName(category.Category.CategoryName)
                    )
                {
                    returnData.ErrorCode = (int)ErrorCode.Invalid;
                    returnData.Message = "Dữ liệu đầu vào không hợp lệ";
                    return returnData;
                }

                // Kiểm tra tồn tại
                var currentCategory = productDBContext.Categories
                    .Where(s => 
                        s.CategoryId == category.Category.CategoryId
                        || s.CategoryName == category.Category.CategoryName
                    ).FirstOrDefault();

                if (currentCategory == null)
                {
                    returnData.ErrorCode = (int)ErrorCode.NotExist;
                    returnData.Message = "Sản phẩm này không tồn tại trên hệ thống";
                    return returnData;
                }

                productDBContext.Categories.Update(category.Category);

                if (category.Details != null)
                    foreach (var item in category.Details)
                    {
                        if (!productDBContext.CategoryDetails
                            .Any(s => s.CDID == item.CDID))
                        {
                            productDBContext.CategoryDetails.Add(item);
                            continue;
                        }

                        productDBContext.CategoryDetails.Update(item);
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
