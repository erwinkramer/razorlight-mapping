using System.Text.Json;
using System.Xml.Linq;
using Microsoft.Extensions.DependencyInjection;
using RazorLight;
using RazorLight.Extensions;

public static class RazorLightEngineHelper
{
    private static string TemplatesPath => Path.Combine(AppContext.BaseDirectory, "Templates");

    public static RazorLightEngine GetRazorLightEngine()
    {
        var engine = new RazorLightEngineBuilder()
            .UseFileSystemProject(TemplatesPath)
            .UseMemoryCachingProvider()
            .Build();

        return engine;
    }

    public static void AddRazorLightEngine(this IServiceCollection services)
    {
        services.AddRazorLight()
            .UseFileSystemProject(TemplatesPath)
            .UseMemoryCachingProvider();
    }

    public static void AddRazorLightTemplatePrecompiler(this IServiceCollection services, IEnumerable<string> templateNames)
    {
        services.AddHostedService(provider =>
            new RazorLightTemplatePrecompiler(
                provider.GetRequiredService<IRazorLightEngine>(),
                templateNames
            )
        );
    }

    public static async Task<string> RunRazorLightJsonMapping(IRazorLightEngine engine, ITemplatePage compiledJsonMap)
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

    public static async Task<string> RunRazorLightXmlMapping(IRazorLightEngine engine, ITemplatePage compiledXmlMap)
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
