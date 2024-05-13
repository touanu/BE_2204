namespace CommonLibs
{
    public class ReturnData
    {
        public int ErrorCode { get; set; } = 0;
        public string Message { get; set; }
    }

    public enum ErrorCode
    {
        Success = 0,
        Failure = -1,
        Exception = -99,
        EqualNull = -2,
        Invalid = -3,
        NotExist = -4,
        AlreadyExist = -5,
        NotAvailable = -6,
    }
}
