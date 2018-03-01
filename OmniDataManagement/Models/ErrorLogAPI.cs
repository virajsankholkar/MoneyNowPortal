using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniDataManagement.Models
{
    public class ErrorLogAPI
    {
        [JsonProperty("Error")]
        public string Error { get; set; }
        [JsonProperty("POC")]
        public string POC { get; set; }
    }
}
