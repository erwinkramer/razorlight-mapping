using System.Text.Json;

public class ViewModelDocJson
{
    public string FileName { get; set; } = string.Empty;
    public required JsonDocument JsonDocument { get; set; }
}