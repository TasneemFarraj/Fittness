namespace Fittness.Response
{
    public class ResponseStandardJsonApi
    {
        public int Count { get; set; }
        public bool Success { get; set; }
        public int Code { get; set; }
        public object? Message { get; set; }
        public object? Result { get; set; }
    }

    public class NullColumns
    {

    }
    public class JwtAuthResponse
    {
        public string? nameid { get; set; }
        public string? given_name { get; set; }
        public string? unique_name { get; set; }
        public string? jti { get; set; }
        public string? exp { get; set; }
        public string? iss { get; set; }
        public string? aud { get; set; }
        public string? UserType { get; set; }
    }
}
