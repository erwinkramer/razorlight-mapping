using System.Text.Json;

public static partial class TemplateHelper
{
    public static string GetStringOrDefault(this JsonElement element, string fallback)
    {
        return element.ValueKind != JsonValueKind.Undefined
            ? element.ToString()
            : fallback;
    }

    public static string GetStringOrDefault(this JsonElement element, string propertyName, string fallback)
    {
        return element.TryGetProperty(propertyName, out var prop)
            ? prop.GetStringOrDefault(fallback)
            : fallback;
    }
}
