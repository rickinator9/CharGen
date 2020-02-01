using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen
{
    /// <summary>
    /// Definition for the JSON parsed from the config file.
    /// </summary>
    class Config
    {
        [JsonProperty("ckii_folder_path")]
        public string CKIIPath { get; set; }

        [JsonProperty("mod_folder_path")]
        public string ModPath { get; set; }

        [JsonProperty("first_char_id")]
        public int FirstCharId { get; set; }

        [JsonProperty("dynasty_id")]
        public int DynastyId { get; set; }

        [JsonProperty("culture")]
        public string Culture { get; set; }

        [JsonProperty("religion")]
        public string Religion { get; set; }

        [JsonProperty("min_age")]
        public int MinimumAge { get; set; }

        [JsonProperty("min_fertile_age")]
        public int MinimumFertileAge { get; set; }

        [JsonProperty("max_age")]
        public int MaximumAge { get; set; }

        [JsonProperty("max_fertile_age")]
        public int MaximumFertileAge { get; set; }

        [JsonProperty("min_year")]
        public int MinimumYear { get; set; }

        [JsonProperty("max_year")]
        public int MaximumYear { get; set; }

        [JsonProperty("max_succession_year")]
        public int MaximumSuccessionYear { get; set; }
    }
}
