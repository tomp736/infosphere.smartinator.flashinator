using System.Text.Json.Serialization;

namespace flashinator.core;

public class Flashinator
{
    [JsonPropertyName("category")]
    public string Category { get; set; }

    [JsonPropertyName("details")]
    public string Details { get; set; }

    [JsonPropertyName("front")]
    public Card Front { get; set; }

    [JsonPropertyName("back")]
    public Card Back { get; set; }
    

    public class Card
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("audio")]
        public string Audio { get; set; }

        [JsonPropertyName("video")]
        public string Video { get; set; }

        [JsonPropertyName("interactive")]
        public bool Interactive { get; set; }
    }
}