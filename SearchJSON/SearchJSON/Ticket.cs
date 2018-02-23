using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace SearchJSON
{
    public class Ticket
    {

        [JsonProperty("_id")]
        public string _id { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("external_id")]
        public string external_id { get; set; }

        [JsonProperty("created_at")]
        public string created_at { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("subject")]
        public string subject { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("priority")]
        public string priority { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("submitter_id")]
        public int submitter_id { get; set; }

        [JsonProperty("assignee_id")]
        public int assignee_id { get; set; }

        [JsonProperty("organization_id")]
        public int organization_id { get; set; }

        [JsonProperty("tags")]
        public IList<string> tags { get; set; }

        [JsonProperty("has_incidents")]
        public bool has_incidents { get; set; }

        [JsonProperty("due_at")]
        public string due_at { get; set; }

        [JsonProperty("via")]
        public string via { get; set; }

        public override string ToString()
        {
            string tagsVal = "";
            if (tags.Count > 0)
                tagsVal = string.Join(",", tags);

            return (
            "_id:               " + _id             + "\n" +
            "url:               " + url             + "\n" +
            "external_id:       " + external_id     + "\n" +
            "created_at:        " + created_at      + "\n" +
            "type:              " + type            + "\n" +
            "subject:           " + subject         + "\n" +
            "description:       " + description     + "\n" +
            "priority:          " + priority        + "\n" +
            "status:            " + status          + "\n" +
            "submitter_id:      " + submitter_id    + "\n" +
            "assignee_id:       " + assignee_id     + "\n" +
            "organization_id:   " + organization_id + "\n" +
            "tags :             " + tagsVal         + "\n" +
            "has_incidents:     " + has_incidents   + "\n" +
            "due_at:            " + due_at          + "\n" +
            "via:               " + via             + "\n" 
            );
        }
    }
}
