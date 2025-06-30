using System.Xml.Linq;

public class ViewModelDocXml
{
    public string FileName { get; set; } = string.Empty;
    public required XDocument XDocument { get; set; }
}