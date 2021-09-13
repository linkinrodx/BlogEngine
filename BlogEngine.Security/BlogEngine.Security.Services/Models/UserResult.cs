namespace BlogEngine.Security.Services.Models
{
    public class UserResult
    {
        public int UserId { get; set; }
        public short RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public byte State { get; set; }

        public RoleResult Role { get; set; }
    }
}
