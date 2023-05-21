namespace UrlShortenerBackend.Models
{
    public partial class UserInfo
    {
        public int UserId { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool IsAdmin { get; set; }

        public UserInfo(User user)
        {
            UserId = user.UserId;
            Username = user.Username;
            Email = user.Email;
            IsAdmin = user.IsAdmin;
        }
    }
}
