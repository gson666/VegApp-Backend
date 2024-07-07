﻿namespace Backend_almog.Helpers
{
    public class JwtSettings
    {
        public string SecurityKey { get; set; } = string.Empty;
        public string ValidIssuer { get; set; } = string.Empty;
        public string ValidAudience { get; set; } = string.Empty;
        public int ExpirationInMinutes { get; set; }
    }

}
