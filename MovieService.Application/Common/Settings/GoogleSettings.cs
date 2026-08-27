namespace MovieService.Application.Common.Settings
{
    public class GoogleSettings
    {
        // This is the Web Client ID from google, from Google Cloud Console - OAuth 2.0 client
        // When backend verify ID Token, they are gonna verify if token's aud is matching our Client ID
        public string ClientId { get; set; } = string.Empty;
    }
}
