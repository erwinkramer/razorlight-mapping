using System.Text.Json;
using System.Xml.Linq;
using RazorLight;

namespace MappingEngine;

public class Engine
{
    public static RazorLightEngine GetEngine()
    {
        var engine = new RazorLightEngineBuilder()
            .UseFileSystemProject(Path.Combine(AppContext.BaseDirectory, "Templates"))
            .UseMemoryCachingProvider()
            .Build();

        return engine;
    }

    public static async Task<string> RunRazorLightJsonMapping(RazorLightEngine engine, ITemplatePage compiledJsonMap)
    {
        var fileName = "input.json";
        using var jsonStream = File.OpenRead(Path.Combine(AppContext.BaseDirectory, "DataSamples", fileName));
        var modelDoc = new ViewModelDocJson
        {
            FileName = fileName,
            JsonDocument = JsonDocument.Parse(jsonStream)
        };
        return await engine.RenderTemplateAsync(compiledJsonMap, modelDoc);
    }

    public static async Task<string> RunRazorLightXmlMapping(RazorLightEngine engine, ITemplatePage compiledXmlMap)
    {
        var fileName = "input.xml";
        var modelDoc = new ViewModelDocXml
        {
            FileName = fileName,
            XDocument = XDocument.Load(Path.Combine(AppContext.BaseDirectory, "DataSamples", fileName))
        };
        return await engine.RenderTemplateAsync(compiledXmlMap, modelDoc);
    }

    public static string PrettyPrintXml(string xml)
    {
        var doc = XDocument.Parse(xml);
        return doc.ToString();
    }
}
