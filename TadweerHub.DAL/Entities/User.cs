using TadweerHub.DAL.Enums;

namespace TadweerHub.DAL.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public UserRole Role { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
