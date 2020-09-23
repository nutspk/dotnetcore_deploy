using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerokuDeployment.Models
{
    public partial class LineResponse
    {
        public DateTime EventDate { get; set; } = DateTime.Now;

        [JsonProperty("events")]
        public List<Event> Events { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }
    }

    public partial class Event
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("replyToken")]
        public string ReplyToken { get; set; }

        [JsonProperty("source")]
        public Source Source { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("message")]
        public Message Message { get; set; }
    }

    public partial class Message
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public partial class Source
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("groupId")]
        public string GroupId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
