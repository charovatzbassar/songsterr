using System.Text.Json.Serialization;

namespace Project_Task.Genius;

public class GeniusResponse
{
    [JsonPropertyName("response")]
    public GeniusHits Response { get; set; }
}

public class GeniusHits
{
    [JsonPropertyName("hits")]
    public List<GeniusHit> Hits { get; set; }
}

public class GeniusHit
{
    [JsonPropertyName("result")]
    public GeniusSong Result { get; set; }
}

public class GeniusSong
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyName("primary_artist")]
    public GeniusArtist Artist { get; set; }
}


public class GeniusArtist
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
}