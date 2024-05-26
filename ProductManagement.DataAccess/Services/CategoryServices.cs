using CommonLibs;
using ProductManagement.DataAccess.DBContext;
using ProductManagement.DataAccess.IServices;
using ProductManagement.DataAccess.Objects;

namespace ProductManagement.DataAccess.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ProductDBContext productDBContext = new();

        public async Task<SaveChangesReturnData> Add(Category category)
        {
            var returnData = new SaveChangesReturnData();

            try
            {
                // Kiểm tra dữ liệu nhập vào
                if (category == null
                    || Validation.IsName(category.CategoryName)
                    )
                {
                    returnData.ErrorCode = (int)ErrorCode.Invalid;
                    returnData.Message = "Dữ liệu đầu vào không hợp lệ";
                    return returnData;
                }

                // Kiểm tra trùng
                var currentProduct = productDBContext.Categories.ToList()
                    .Where(s => s.CategoryName == category.CategoryName).FirstOrDefault();

                if (currentProduct != null)
                {
                    returnData.ErrorCode = (int)ErrorCode.AlreadyExist;
                    returnData.Message = "Nhân viên này đã tồn tại trên hệ thống";
                    return returnData;
                }

                // Thêm nhân viên
                productDBContext.Categories.Add(category);
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

        public async Task<SaveChangesReturnData> Delete(Category category)
        {
            var returnData = new SaveChangesReturnData();

            try
            {
                // Kiểm tra dữ liệu nhập vào
                if (category.CategoryId < 0
                    || category == null
                    )
                {
                    returnData.ErrorCode = (int)ErrorCode.Invalid;
                    returnData.Message = "Dữ liệu đầu vào không hợp lệ";
                    return returnData;
                }

                /* Tìm kiếm nhân viên theo ID
                var category = productDBContext.Categories
                    .Where(s => s.CategoryID == category.CategoryID).FirstOrDefault();

                if (category == null)
                {
                    returnData.ErrorCode = (int)ErrorCode.NotExist;
                    returnData.Message = "Không tồn tại nhân viên này";
                    return returnData;
                }
                */

                // Xoá nhân viên
                productDBContext.Categories.Remove(category);
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

        public List<Category> GetAll()
        {
            return [.. productDBContext.Categories];
        }

        public async Task<SaveChangesReturnData> Update(Category category)
        {
            var returnData = new SaveChangesReturnData();

            try
            {
                // Kiểm tra dữ liệu nhập vào
                if (category == null
                    || Validation.IsName(category.CategoryName)
                    )
                {
                    returnData.ErrorCode = (int)ErrorCode.Invalid;
                    returnData.Message = "Dữ liệu đầu vào không hợp lệ";
                    return returnData;
                }

                productDBContext.Categories.Update(category);
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
