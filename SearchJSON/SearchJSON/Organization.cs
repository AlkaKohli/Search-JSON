using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace SearchJSON
{
    public class Organization
    {
        [JsonProperty("_id")]
        public int _id { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("external_id")]
        public string external_id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("domain_names")]
        public IList<string> domain_names { get; set; }

        [JsonProperty("created_at")]
        public string created_at { get; set; }

        [JsonProperty("details")]
        public string details { get; set; }

        [JsonProperty("shared_tickets")]
        public bool shared_tickets { get; set; }

        [JsonProperty("tags")]
        public IList<string> tags { get; set; }

        public override string ToString()
        {
            string tagsVal = "";
            if (tags.Count > 0)
                tagsVal = string.Join(",", tags);

            string domain_namesVal = "";
            if (domain_names.Count > 0)
                domain_namesVal = string.Join(",", domain_names);

            return (
            "_id:               " + _id             + "\n" +
            "url:               " + url             + "\n" +
            "external_id:       " + external_id     + "\n" +
            "name:              " + name            + "\n" +
            "domain_names:      " + domain_namesVal + "\n" +
            "created_at:        " + created_at      + "\n" +
            "details:           " + details         + "\n" +
            "shared_tickets:    " + shared_tickets  + "\n" +
            "tags:              " + tagsVal 
            );
        }
    }   
}
