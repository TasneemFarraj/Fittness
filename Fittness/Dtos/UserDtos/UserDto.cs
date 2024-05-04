using Fittness.Data.Enum;

namespace Fittness.Dtos.UserDtos
{
    public class UserDto
    {
        public int? Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public UserTypeEnum UserType { get; set; }
        public string Token { get; set; }
    }
    public class WriteUserDto
    {
        public int? Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
