namespace Template.Service.Api.Rest.Domain.Model
{
    public class AccessToken
    {
        public string Token { get; set; } = string.Empty;
        public string Type { get; set; } = "Bearer";
        public int MinutesOfExpiration { get; set; }
    }
}
