using BE2024.DataAccess.Objects;
using CommonLibs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE2024.DataAccess.Implementations
{
    public class DsHangHoa
    {
        private readonly List<HangHoa> ListProducts = new List<HangHoa>();

        public ReturnData Add(HangHoa hangHoa)
        {
            ReturnData returnData = new ReturnData();
            if (hangHoa == null)
            {
                returnData.ErrorCode = -1;
                returnData.Message = "Dữ liệu không được để trống!";
                return returnData;
            }

            if (!Validation.IsName(hangHoa.TenHang))
            {
                returnData.ErrorCode = -2;
                returnData.Message = "Tên hàng không được để trống!";
            }

            ListProducts.Add(hangHoa);
            return returnData;
        }

        
    }
}
