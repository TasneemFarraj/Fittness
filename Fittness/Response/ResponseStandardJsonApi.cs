namespace Fittness.Response
{
    public class ResponseStandardJsonApi
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public bool Success { get; set; }
        public int Code { get; set; }
        public object? Message { get; set; }
        public object? Result { get; set; }
    }

    public class NullColumns
    {

    }
}
