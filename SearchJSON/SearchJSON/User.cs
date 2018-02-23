using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace SearchJSON
{
    class User
    {
        [JsonProperty("_id")]
        public int _id { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("external_id")]
        public string external_id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("alias")]
        public string alias { get; set; }

        [JsonProperty("created_at")]
        public string created_at { get; set; }

        [JsonProperty("active")]
        public bool active { get; set; }

        [JsonProperty("verified")]
        public bool verified { get; set; }

        [JsonProperty("shared")]
        public bool shared { get; set; }

        [JsonProperty("locale")]
        public string locale { get; set; }

        [JsonProperty("timezone")]
        public string timezone { get; set; }

        [JsonProperty("last_login_at")]
        public string last_login_at { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("phone")]
        public string phone { get; set; }

        [JsonProperty("signature")]
        public string signature { get; set; }

        [JsonProperty("organization_id")]
        public int organization_id { get; set; }

        [JsonProperty("tags")]
        public IList<string> tags { get; set; }

        [JsonProperty("suspended")]
        public bool suspended { get; set; }

        [JsonProperty("role")]
        public string role { get; set; }

        public override string ToString()
        {
            string tagsVal = "";
            if(tags.Count > 0)
                 tagsVal = string.Join(",", tags);

                return (
            "_id:               " + _id             + "\n" +
            "url:               " + url             + "\n" +
            "external_id:       " + external_id     + "\n" +
            "name:              " + name            + "\n" +
            "alias:             " + alias           + "\n" +
            "created_at:        " + created_at      + "\n" +
            "active:            " + active          + "\n" +
            "verified:          " + verified        + "\n" +
            "shared:            " + shared          + "\n" +
            "locale:            " + locale          + "\n" +
            "timezone:          " + timezone        + "\n" +
            "last_login_at:     " + last_login_at   + "\n" +
            "email:             " + email           + "\n" +
            "phone:             " + phone           + "\n" +
            "signature:         " + signature       + "\n" +
            "organization_id:   " + organization_id + "\n" +
            "tags:              " + tagsVal         + "\n" +
            "suspended:         " + suspended       + "\n" +
            "role:              " + role            + "\n"
            );
        }        
    }
}
