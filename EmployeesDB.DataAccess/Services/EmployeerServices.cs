using CommonLibs;
using EmployeesDB.DataAccess.DBContext;
using EmployeesDB.DataAccess.IServices;
using EmployeesDB.DataAccess.Objects;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EmployeesDB.DataAccess.Services
{
    public class EmployeerServices : IEmployeerServices
    {
        private readonly EmployeesDBContext employeesDBContext = new();
        public async Task<EmployeerSaveReturnData> Create(Employeer employeer)
        {
            var returnData = new EmployeerSaveReturnData();

            try
            {
                // Kiểm tra dữ liệu nhập vào
                if (employeer == null
                    || Validation.IsName(employeer.FullName)
                    )
                {
                    returnData.ErrorCode = (int)ErrorCode.Invalid;
                    returnData.Message = "Dữ liệu đầu vào không hợp lệ";
                    return returnData;
                }

                // Kiểm tra trùng
                var currentEmployeer = employeesDBContext.Employeers.ToList()
                    .Where(s => s.FullName == employeer.FullName).FirstOrDefault();

                if (currentEmployeer != null)
                {
                    if (currentEmployeer.Birthday == employeer.Birthday)
                    {
                        returnData.ErrorCode = (int)ErrorCode.AlreadyExist;
                        returnData.Message = "Nhân viên này đã tồn tại trên hệ thống";
                        return returnData;
                    }
                }

                // Thêm nhân viên
                employeesDBContext.Employeers.Add(employeer);
                returnData.ErrorCode = (int)ErrorCode.Success;
                returnData.SaveChangesCode = await employeesDBContext.SaveChangesAsync();
                returnData.Message = "Thêm vào cơ sở dữ liệu thành công!";
                returnData.Employeer = employeer;
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

        public async Task<EmployeerSaveReturnData> Delete(int employeerID)
        {
            var returnData = new EmployeerSaveReturnData();

            try
            {
                // Kiểm tra dữ liệu nhập vào
                if (employeerID < 0)
                {
                    returnData.ErrorCode = (int)ErrorCode.Invalid;
                    returnData.Message = "Dữ liệu đầu vào không hợp lệ";
                    return returnData;
                }

                // Tìm kiếm nhân viên theo ID
                var employeer = employeesDBContext.Employeers
                    .Where(s => s.EmployeerId == employeerID).FirstOrDefault();

                if (employeer == null)
                {
                    returnData.ErrorCode = (int)ErrorCode.NotExist;
                    returnData.Message = "Không tồn tại nhân viên này";
                    return returnData;
                }

                // Xoá nhân viên
                employeesDBContext.Employeers.Remove(employeer);
                returnData.ErrorCode = (int)ErrorCode.Success;
                returnData.SaveChangesCode = await employeesDBContext.SaveChangesAsync();
                returnData.Message = "Thêm vào cơ sở dữ liệu thành công!";
                returnData.Employeer = employeer;

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

        public Task<Employeer?> GetEmployeerByID(int employeerID)
        {
            return employeesDBContext.Employeers
                .Where(item => item.EmployeerId == employeerID)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Employeer?>> GetEmployeerByName(string employeerName)
        {
            return [.. employeesDBContext.Employeers
                .Where(item => item.FullName == employeerName)];
        }

        public Task<Employeer?> GetEmployeerByProcessID(int processID)
        {
            return employeesDBContext.Employeers
                .Where(item => item.ProcessID == processID)
                .FirstOrDefaultAsync();
        }

        public async Task<EmployeerSaveReturnData> Update(Employeer employeer)
        {
            var returnData = new EmployeerSaveReturnData();

            try
            {
                // Kiểm tra dữ liệu nhập vào
                if (employeer == null
                    || Validation.IsName(employeer.FullName)
                    )
                {
                    returnData.ErrorCode = (int)ErrorCode.Invalid;
                    returnData.Message = "Dữ liệu đầu vào không hợp lệ";
                    return returnData;
                }

                employeesDBContext.Employeers.Update(employeer);
                returnData.ErrorCode = (int)ErrorCode.Success;
                returnData.SaveChangesCode = await employeesDBContext.SaveChangesAsync();
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
