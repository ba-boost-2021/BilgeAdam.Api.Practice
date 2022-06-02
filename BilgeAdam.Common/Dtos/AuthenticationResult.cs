namespace BilgeAdam.Common.Dtos
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}