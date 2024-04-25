namespace BE2024.DataAccess.Objects
{
    public class ReturnData
    {
        public int ErrorCode { get; set; } = 0;
        public string Message { get; set; }
    }

    public enum ErrorCode
    {
        Success = 0,
        EqualNull = -1,
        Invalid = -2,
        NotExist = -3,
        AlreadyExist = -4,
        NotAvailable = -5
    }
}
