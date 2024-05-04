using Nancy.Json;

namespace Fittness.Authorization
{
    public class SecuredHelper
    {
        public static Response.JwtAuthResponse GetInfoFromToken(string Token)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string[] source = Token.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            Response.JwtAuthResponse authResponse = serializer.Deserialize<Response.JwtAuthResponse>(source[1]);
            return authResponse;
        }
    }
}
