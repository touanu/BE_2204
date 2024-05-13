using CommonLibs;
using Microsoft.Data.SqlClient;
using Storage.DataAccess.IServices;
using Storage.DataAccess.Objects;

namespace Storage.DataAccess.Services
{
    public class ProductServices : IProductServices
    {
        public async Task<Product> GetProduct(string searchValue)
        {
            try
            {
                SqlConnection connect = DBHelper.GetSqlConnection();
                var cmd = new SqlCommand("ProductGetInfo", connect)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@SearchValue", searchValue);
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                var product = new Product()
                {
                    ProductID = reader["ProductID"] != null ? Convert.ToInt32(reader["ProductID"]) : 0,
                    ProductName = reader["ProductName"] != null ? Convert.ToString(reader["ProductName"]) : string.Empty,
                    ExpiresDate = reader["ExpiresDate"] != null ? Convert.ToDateTime(reader["ExpiresDate"]) : DateTime.MinValue,
                    CategoryID = reader["CategoryID"] != null ? Convert.ToInt32(reader["CategoryID"]) : 0,
                    Quantity = reader["Quantity"] != null ? Convert.ToInt32(reader["Quantity"]) : 0
                };

                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProductInsertReturnData> ProductInsert(Product product)
        {
            var returnData = new ProductInsertReturnData();

            try
            {
                if (product == null)
                {
                    returnData.ErrorCode = (int)ErrorCode.EqualNull;
                    returnData.Message = "Sản phẩm không thể để trống!";
                    return returnData;
                }

                if (Validation.IsName(product.ProductName))
                {
                    returnData.ErrorCode = (int)ErrorCode.Invalid;
                    returnData.Message = "Tên sản phẩm không hợp lệ!";
                    return returnData;
                }

                SqlConnection connect = DBHelper.GetSqlConnection();

                SqlCommand cmd = new("ProductInsert", connect)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                cmd.Parameters.AddWithValue("@ExpiresDate", product.ExpiresDate);
                cmd.Parameters.AddWithValue("@CategoryID", product.CategoryID);

                cmd.ExecuteNonQuery();

                int rs = cmd.Parameters["@ResponseCode"].Value != DBNull.Value ?
                    Convert.ToInt32(cmd.Parameters["@ResponseCode"].Value) : 0;

                if (rs < 0)
                {
                    returnData.ErrorCode = (int)ErrorCode.Failure;
                    returnData.Message = "Thêm dữ liệu thất bại";
                    return returnData;
                }

                returnData.ErrorCode = rs;
                returnData.Message = "Thêm dữ liệu thành công!";
                returnData.Product = product;
                return returnData;
            }
            catch (Exception ex)
            {
                returnData.ErrorCode = (int)ErrorCode.Exception;
                returnData.Message = ex.Message;
                return returnData;
            }
        }
    }
}
