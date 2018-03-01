using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace OmniDataManagement
{
    public class LoginRequestDetails
    {
        [Required(ErrorMessage = "UserName is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public int InstitutionID { get; set; }
        public int POCType { get; set; }
        public int TTL { get; set; }
    }

   
    public class LoginResponseDetails
    {
        [JsonProperty("Token")]
        public string Token { get; set; }
        [JsonProperty("UserName")]
        public string UserName { get; set; }
        [JsonProperty("Payload")]
        public int Payload { get; set; }
        [JsonProperty("StatusCode")]
        public int StatusCode { get; set; }
        [JsonProperty("RoleID")]
        public int RoleID { get; set; }
        [JsonProperty("Permissions")]
        public List<PermissionsList> Permissions { get; set; }
    }

    public class PermissionsList
    {
        [JsonProperty("POC")]
        public string POC { get; set; }
        [JsonProperty("Allowed")]
        public bool Allowed { get; set; }
    }
    
}
