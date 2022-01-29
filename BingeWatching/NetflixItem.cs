using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BingeWatching
{
    public class NetflixItem
    {
        [JsonPropertyName("id")]
        public Guid id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("overview")]
        public string Overview { get; set; }

        [JsonPropertyName("imdb_rating")]
        public double? ImdbRanking { get; set; }


        public int UserRanking { get; set; }

    }

}
