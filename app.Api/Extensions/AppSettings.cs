namespace app.Api.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; }
        /// <summary>
        /// Expiração em horas
        /// </summary>
        public int HourExpiration { get; set; }
        /// <summary>
        /// Emissor
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// valido em
        /// </summary>
        public string UrlAudience { get; set; }
    }
}
