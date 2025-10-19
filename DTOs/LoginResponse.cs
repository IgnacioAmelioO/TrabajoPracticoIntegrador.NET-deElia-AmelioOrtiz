using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTOs
{
    public class LoginResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; } = string.Empty;
        
        [JsonPropertyName("expiresAt")]
        public DateTime ExpiresAt { get; set; }
        
        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyName("Id_persona")]
        public int Id_persona { get; set; }

       
    

        

        
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Token) && 
                   !string.IsNullOrEmpty(Username) && 
                   ExpiresAt > DateTime.UtcNow;
        }
    }
}