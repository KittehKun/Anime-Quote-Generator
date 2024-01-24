using Newtonsoft.Json;

namespace Anime_Quote_Generator
{
    internal class AnimeQuote
    {
        [JsonProperty("anime")]
        public string? Anime { get; set; }

        [JsonProperty("character")]
        public string? Character { get; set; }

        [JsonProperty("quote")]
        public string? Quote { get; set; }

        public override string ToString()
        {
            return $"{WrapText(Quote, 60)} - {Character ?? "Unknown Character"} ({Anime ?? "Unknown Anime"})";
        }

        private static string WrapText(string text, int maxLineLength)
        {
            if (text.Length <= maxLineLength)
            {
                return text;
            }

            var lines = new List<string>();

            while (text.Length > maxLineLength)
            {
                int lastSpace = text.LastIndexOf(' ', maxLineLength);
                if (lastSpace == -1)
                {
                    lastSpace = maxLineLength;
                }

                lines.Add(text.Substring(0, lastSpace));
                text = text.Substring(lastSpace + 1);
            }

            lines.Add(text);

            return string.Join(Environment.NewLine, lines);
        }
    }
}
